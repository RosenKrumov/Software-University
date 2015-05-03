using System;
using System.Text;

namespace ConsoleForum.Entities.Users
{
    using System.Collections.Generic;
    using Contracts;

    public class User : IUser
    {
        private int id;
        private string username;
        private string password;
        private string email;
        
        public User(int id, string name, string password, string email)
        {
            this.Id = id;
            this.Username = name;
            this.Password = password;
            this.Email = email;
            this.Questions = new List<IQuestion>();
            this.LoggedIn = false;
        }

        public int Id
        {
            get { return this.id; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Id must be positive.");
                }
                this.id = value;
            }
        }

        public string Username
        {
            get { return this.username; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Username must not be empty.");
                }
                this.username = value;
            }
        }

        public string Password
        {
            get { return this.password; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Password must not be empty.");
                }
                this.password = value;
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Email must not be empty");
                }
                this.email = value;
            }
        }

        public bool LoggedIn { get; set; }

        public IList<IQuestion> Questions { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            return sb.ToString();
        }
    }
}
