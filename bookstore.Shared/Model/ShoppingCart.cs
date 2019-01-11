using System;
using System.Collections.Generic;

namespace bookstore.Server.Model
{
    public partial class ShoppingCart
    {
        public ShoppingCart()
        {
            InverseCardItem = new HashSet<ShoppingCart>();
            InverseUser = new HashSet<ShoppingCart>();
        }

        public int ShoppingCartId { get; set; }
        public int UserId { get; set; }
        public int CardItemId { get; set; }
        public int GrandTotal { get; set; }

        public ShoppingCart CardItem { get; set; }
        public ShoppingCart User { get; set; }
        public ICollection<ShoppingCart> InverseCardItem { get; set; }
        public ICollection<ShoppingCart> InverseUser { get; set; }
    }
}
