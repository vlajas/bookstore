using System.Collections.Generic;
using bookstore.Shared.Entities;

namespace bookstore.Core.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<string> Roles { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
