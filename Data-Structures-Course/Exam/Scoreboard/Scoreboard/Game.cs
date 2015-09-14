namespace Scoreboard
{
    using System;

    public class Game : IComparable<Game>
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public int CompareTo(Game other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
