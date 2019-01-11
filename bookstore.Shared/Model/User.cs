using System.Collections.Generic;

namespace bookstore.Shared.Model
{
    public class User : BaseEntity
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public virtual List<ShoppingCart> ShoppingCarts { get; set; }
    }
}
