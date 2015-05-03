using System;
using System.Collections.Generic;
using ProjectStructure.Interfaces;

namespace ProjectStructure.Items
{
    abstract class Item : IItem
    {
        protected string id;
        protected string title;
        protected decimal price;
        protected List<string> genres;

        public string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 4)
                {
                    throw new ArgumentException("Invalid ID");
                }
                this.id = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }
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
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price must be positive.");
                }
                this.price = value;
            }
        }

        public List<string> Genres
        {
            get
            {
                return this.genres;
            }
            set
            {
                foreach (var genre in value)
                {
                    if (string.IsNullOrEmpty(genre))
                    {
                        throw new ArgumentNullException("Genres must not be empty.");
                    }
                    this.genres = value;
                }
            }
        }
    }
}
