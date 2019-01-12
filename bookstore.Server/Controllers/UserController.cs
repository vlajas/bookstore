using System;
using System.Collections.Generic;
using System.Linq;
using bookstore.Shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.Server.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly BookstoreDbContext _context;

        public UserController(BookstoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("[action]")]
        public List<User> Get()
        {
            List<User> users = _context.User.ToList();

            return users;
        }

        [HttpGet]
        [Route("[action]/{id?}")]
        public User Get(int id)
        {
            User user = _context.User.Find(id);

            return user;
        }

        [HttpPut]
        [Route("[action]")]
        public bool Create([FromBody]User user)
        {
            // TODO: Add validation logic

            try
            {
                _context.User.Add(user);

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
        public bool Update([FromBody]User user)
        {
            try
            {
                _context.User.Update(user);

                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                // TODO: Add exception logging?

                return false;
            }
        }

        [HttpDelete]
        [Route("[action]/{id?}")]
        public bool Delete(int id)
        {
            User user = _context.User.Find(id);

            if (user == null)
            {
                return false ;
            }

            try
            {
                _context.User.Remove(user);
             
                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                // TODO: Add exception logging?

                return false;
            }
        }
    }
}
