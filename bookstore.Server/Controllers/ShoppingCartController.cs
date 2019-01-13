using System;
using System.Linq;
using bookstore.Core.Data;
using bookstore.Core.Models;
using bookstore.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.Server.Controllers
{
    [Route("api/[controller]")]
    public class ShoppingCartController : Controller
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<ShoppingCartItem> _shoppingCartItemRepository;
        
        public ShoppingCartController(IRepository<ShoppingCartItem> shoppingCartItemRepository, IRepository<User> userRepository, IRepository<Book> bookRepository)
        {
            _shoppingCartItemRepository = shoppingCartItemRepository;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }

        [HttpPost]
        [Route("[action]")]
        public ShoppingCartItem AddToCart([FromBody]AddToCartRequest request)
        {
            User user = _userRepository.Get(request.UserId);

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            Book book = _bookRepository.Get(request.BookId);

            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            ShoppingCartItem sci;

            if (user.ShoppingCartItems.Any(x => x.BookId == book.Id))
            {
                sci = user.ShoppingCartItems.FirstOrDefault(x => x.BookId == book.Id);

                sci.Quantity += request.Quantity;

                _shoppingCartItemRepository.Update(sci);
            }
            else
            {
                sci = new ShoppingCartItem
                {
                    UserId = user.Id,
                    BookId = book.Id,
                    Price = book.Price,
                    Quantity = request.Quantity
                };

                _shoppingCartItemRepository.Insert(sci);
            }

            return sci;
        }

        [HttpDelete]
        [Route("{id?}")]
        public bool DeleteShoppingCartItem(int id)
        {
            ShoppingCartItem sci = _shoppingCartItemRepository.Get(id);

            return sci != null && _shoppingCartItemRepository.Delete(sci);
        }
    }
}
