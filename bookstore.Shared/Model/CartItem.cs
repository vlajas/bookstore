using System;
using System.Collections.Generic;

namespace bookstore.Server.Model
{
    public partial class CartItem
    {
        public CartItem()
        {
            InverseBook = new HashSet<CartItem>();
            InverseShoppingCart = new HashSet<CartItem>();
        }

        public int CardItemId { get; set; }
        public int ShoppingCartId { get; set; }
        public int BookId { get; set; }
        public int Qty { get; set; }
        public int Subtotal { get; set; }

        public CartItem Book { get; set; }
        public CartItem ShoppingCart { get; set; }
        public ICollection<CartItem> InverseBook { get; set; }
        public ICollection<CartItem> InverseShoppingCart { get; set; }
    }
}
