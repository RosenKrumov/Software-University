namespace ProjectStructureSolutionAuthor.Models
{
    using System;
    using System.Collections.Generic;

    class Game : Item
    {
        private AgeRestriction ageRestriction;

        public AgeRestriction AgeRestriction { get; set; }

        public Game(string id, string title, decimal price, List<string> genres)
            : base(id, title, price, genres) { }

        public Game(string id, string title, decimal price, string genre, AgeRestriction ageRestriction) 
            : this(id, title, price, new List<string> { genre }) 
        {
            this.AgeRestriction = AgeRestriction.Minor;
        }
    }
}
