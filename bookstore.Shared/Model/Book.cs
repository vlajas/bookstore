﻿using System;

namespace bookstore.Shared.Model
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }

        public decimal Price { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        public DateTime? PublicationDate { get; set; }

        public string Language { get; set; }

        public string ImageUrl { get; set; }

        public string Category { get; set; }

        public int Isbn { get; set; }

        public int NumberOfPages { get; set; }
    }
}
