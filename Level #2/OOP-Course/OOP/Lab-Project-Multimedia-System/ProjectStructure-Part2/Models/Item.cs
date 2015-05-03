namespace ProjectStructureSolutionAuthor.Models
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    abstract class Item : IItem
    {
        private decimal price;
        private string id;
        private string title;
        public string Id
        {
            get { return this.id; }
            set
            {
                if (value.Length < 4 || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid ID.");
                }
                this.id = value;
            }
        }

        public string Title
        {
            get { return this.title; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Title must not be empty.");
                }
                this.title = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Value cannot be negative.");
                }
                this.price = value;
            }
        }

        public List<string> Genres { get; set; }
        
        public Item(string id, string title, decimal price, List<string> genres)
        {
            this.Id = id;
            this.Title = title;
            this.Price = price;
            this.Genres = genres;
        }

        public Item(string id, string title, decimal price)
        {
            this.Id = id;
            this.Title = title;
            this.Price = price;
        }
    }
}