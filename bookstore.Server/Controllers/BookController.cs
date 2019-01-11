using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookstore.Shared.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly BookstoreDbContext _context;

        public BookController(BookstoreDbContext context)
        {
            _context = context;
        }

        [Route("[action]")]
        public List<Book> Get()
        {
            List<Book> books = _context.Book.ToList();

            return books;
        }

        [Route("[action]/{id?}")]
        public Book Get(int id)
        {
            Book book = _context.Book.Find(id);

            return book;
        }

        [HttpPost]
        [Route("[action]")]
        public bool Create([FromBody]Book book)
        {
            // TODO: Add validation logic

            try
            {
                _context.Book.Add(book);

                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                // TODO: Add exception logging?

                return false;
            }
        }

        [HttpPost]
        [Route("[action]")]
        public bool Update([FromBody]Book book)
        {
            try
            {
                _context.Book.Update(book);

                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {           

                return false;
            }
        }

        [HttpPost]
        [Route("[action]/{id?}")]
        public bool Delete(int id)
        {
            Book book = _context.Book.Find(id);

            if (book == null)
            {
                return false;
            }

            try
            {

                _context.Book.Remove(book);
                _context.SaveChanges();

                return true;
            }
            catch(Exception e) {

                return false;
            }

        }
    }
}