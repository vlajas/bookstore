using System.Collections.Generic;

namespace bookstore.Shared.Entities
{
    public class ShoppingCart : BaseEntity
    {
        public int UserId { get; set; }

        public decimal GrandTotal { get; set; }

        public virtual User User { get; set; }

        public virtual List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
