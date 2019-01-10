using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Server.Model
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        public string title { get; set; }

        public int price { get; set; }

        public string author { get; set; }

        public string publisher { get; set; }

        public DateTime publication_date { get; set; }

        public string language { get; set; }

        public string category { get; set; }

        public int isbn { get; set; }

        public int number_of_pages { get; set; }


        public int CardItemId { get; set; }

        public CardItem CardItem { get; set; }
    }
}
