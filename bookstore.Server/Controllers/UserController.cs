using System.Collections.Generic;
using bookstore.Core.Data;
using bookstore.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.Server.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IRepository<User> _userRepository;

        public UserController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public List<User> Get()
        {
            List<User> users = _userRepository.GetAll();

            return users;
        }

        [HttpGet]
        [Route("{id?}")]
        public User Get(int id)
        {
            User user = _userRepository.Get(id);

            return user;
        }

        [HttpPut]
        public bool Create([FromBody]User user)
        {
            // TODO: Add validation logic

            return _userRepository.Insert(user);
        }

        [HttpPost]
        public bool Update([FromBody]User user)
        {
            return _userRepository.Update(user);
        }

        [HttpDelete]
        [Route("{id?}")]
        public bool Delete(int id)
        {
            User user = _userRepository.Get(id);

            return user != null && _userRepository.Delete(user);
        }
    }
}
