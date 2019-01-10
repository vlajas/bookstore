using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Server.Model
{
    public class CardItem
    {
        [Key]
        public int CardItemId { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }

        public int ShoppingCartId { get; set; }

        public virtual List<Book> Books { get; set; }

        public int qty { get; set; }

        public int subtotal { get; set; }
    }
}
