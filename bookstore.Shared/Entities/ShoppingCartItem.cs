﻿namespace bookstore.Shared.Entities
{
    public class ShoppingCartItem : BaseEntity
    {
        public int UserId { get; set; }

        public int BookId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
        
        public virtual User User { get; set; }

        public virtual Book Book { get; set; }
    }
}
