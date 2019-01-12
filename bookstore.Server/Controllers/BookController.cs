using System.Collections.Generic;
using bookstore.Core.Data;
using bookstore.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.Server.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IRepository<Book> _bookRepository;

        public BookController(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public List<Book> Get()
        {
            List<Book> books = _bookRepository.GetAll();

            return books;
        }

        [HttpGet]
        [Route("{id?}")]
        public Book Get(int id)
        {
            Book book = _bookRepository.Get(id);

            return book;
        }

        [HttpPut]
        public bool Create([FromBody]Book book)
        {
            // TODO: Add validation logic

            return _bookRepository.Insert(book);
        }

        [HttpPost]
        public bool Update([FromBody]Book book)
        {
            return _bookRepository.Update(book);
        }

        [HttpDelete]
        [Route("{id?}")]
        public bool Delete(int id)
        {
            Book book = _bookRepository.Get(id);

            return book != null && _bookRepository.Delete(book);
        }
    }
}