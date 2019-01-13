using System.Collections.Generic;

namespace bookstore.Shared.Entities
{
    public class Order : BaseEntity
    { 
        public int UserId { get; set; }

        public int ItemCount { get; set; }

        public decimal OrderTotal { get; set; }

        public virtual User User { get; set; }

        public virtual List<OrderItem> OrderItems { get; set; }
    }
}
