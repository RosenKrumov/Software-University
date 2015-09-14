namespace Scoreboard
{
    using System;

    public class User : IComparable<User>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public int CompareTo(User other)
        {
            return this.Username.CompareTo(other.Username);
        }
    }
}
