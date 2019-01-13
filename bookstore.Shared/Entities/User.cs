using System.Collections.Generic;
using System.Linq;

namespace bookstore.Shared.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public virtual List<UserRoleMapping> UserRoleMappings { get; set; }

        public virtual List<Role> Roles => UserRoleMappings != null ? UserRoleMappings.Select(x => x.Role).ToList() : new List<Role>();

        public virtual List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
