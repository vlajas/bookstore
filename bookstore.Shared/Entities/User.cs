using System.Collections.Generic;

namespace bookstore.Shared.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public virtual List<ShoppingCart> ShoppingCarts { get; set; }

        public virtual List<UserRoleMapping> UserRoleMappings { get; set; }

        public virtual List<Role> Roles { get; set; }
    }
}
