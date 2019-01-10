using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Server.Model
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string email { get; set; }

        public int phone { get; set; }

        public virtual List<ShoppingCart> ShoppingCarts { get; set; }



    }
}
