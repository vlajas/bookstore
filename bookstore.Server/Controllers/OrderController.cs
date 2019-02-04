using System.Collections.Generic;
using System.Linq;
using bookstore.Core.Data;
using bookstore.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.Server.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<User> _userRepository;

        public OrderController(IRepository<Order> orderRepository, IRepository<User> userRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }

        [HttpGet("[action]/{userId}")]
        public List<Order> GetOrdersForUserId(int userId)
        {
            List<Order> orders = _userRepository.Get(userId)?.Orders ?? new List<Order>();

            return orders;
        }

        [HttpGet("[action]/{orderId}", Name = "GetOrder")]
        public Order GetOrder(int orderId)
        {
            Order order = _orderRepository.Get(orderId);

            return order;
        }

        [HttpPost("{userId}")]
        public bool CreateOrder(int userId, [FromBody]IEnumerable<ShoppingCartItem> shoppingCartItems)
        {
            if (userId <= 0)
            {
                return false;
            }

            User user = _userRepository.Get(userId);

            if (user == null)
            {
                return false;
            }

            IEnumerable<ShoppingCartItem> cartItems = shoppingCartItems.ToList();

            if (!cartItems.Any())
            {
                return false;
            }

            List<OrderItem> orderItems = cartItems
                .Select(x => new OrderItem
                {
                    BookId = x.BookId,
                    Price = x.Price,
                    Quantity = x.Quantity
                }).ToList();

            var order = new Order
            {
                ItemCount = orderItems.Count,
                OrderItems = orderItems,
                OrderTotal = orderItems.Sum(x => x.Price * x.Quantity),
                UserId = user.Id
            };

            _orderRepository.Insert(order);

            user.ShoppingCartItems.Clear();

            _userRepository.Update(user);

            return true;
        }
    }
}
