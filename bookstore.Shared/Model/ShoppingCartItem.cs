namespace bookstore.Shared.Model
{
    public class ShoppingCartItem : BaseEntity
    {
        public int ShoppingCartId { get; set; }

        public int BookId { get; set; }

        public int Quantity { get; set; }

        public decimal Subtotal { get; set; }   

        public virtual Book Book { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}
