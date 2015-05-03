namespace ProjectStructureSolutionAuthor.Models
{
    using System;
    using System.Collections.Generic;

    class Video : Item
    {
        private int length;

        public int Length
        {
            get
            {
                return this.length;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Length must be positive.");
                }
            }
        }

        public Video(string id, string title, decimal price, int length, List<string> genres)
            : base (id, title, price, genres)
        {
            this.Length = length;
        }

        public Video(string id, string title, decimal price, int length, string genre)
            : this(id, title, price, length, new List<string>() { genre }) { }
    }
}
