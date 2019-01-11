using System;
using System.Collections.Generic;

namespace bookstore.Server.Model
{
    public partial class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime? PublicationDate { get; set; }
        public string Language { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
        public int Isbn { get; set; }
        public int NumberOfPages { get; set; }
    }
}
