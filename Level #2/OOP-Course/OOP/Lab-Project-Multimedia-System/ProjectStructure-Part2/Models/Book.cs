namespace ProjectStructureSolutionAuthor.Models
{
    using System;
    using System.Collections.Generic;

    class Book : Item
    {
        private string author;

        public string Author
        {
            get
            {
                return this.author;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentException("Author must not be empty and at least 3 symbols long.");
                }
                this.author = value;
            }
        }

        public Book (string id, string title, decimal price, string author, List<string> genres)
            : base(id, title, price, genres)
        {
            this.Author = author;
        }

        public Book (string id, string title, decimal price, string author, string genre) 
            : this(id, title, price, author, new List<string>() { genre })  { }
    }
}
