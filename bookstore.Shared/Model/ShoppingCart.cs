using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Server.Model
{
    public class ShoppingCart
    {
        [Key]
      public int  ShoppingCartId { get; set; }

        public int UserId { get; set; }
        public virtual  User User { get; set; }

        public virtual List<CardItem> CardItems { get; set; }

        public int grand_total;


    }
}
