namespace bookstore.Core.Models
{
    public class AddToCartRequest
    {
        public int UserId { get; set; }

        public int BookId { get; set; }

        public int Quantity { get; set; }
    }
}
