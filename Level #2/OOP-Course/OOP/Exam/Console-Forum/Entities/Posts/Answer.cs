using System;
using System.Text;

namespace ConsoleForum.Entities.Posts
{
    using Contracts;

    public class Answer : IAnswer
    {
        private int id;
        private string body;
        
        public Answer(int id, string body, IUser author)
        {
            this.Id = id;
            this.Body = body;
            this.Author = author;
        }

        public int Id
        {
            get { return this.id; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("ID must be positive");
                }
                this.id = value;
            }
        }

        public string Body
        {
            get { return this.body; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Answer body must not be empty.");
                }
                this.body = value;
            }
        }

        public IUser Author { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var footer = new string('-', 20);
            sb.AppendFormat(
                "[ Answer ID: {0} ]\n" +
                "Posted by: {1}\n" +
                "Answer Body: {2}\n" +
                "{3}\n",
                this.Id,
                this.Author.Username,
                this.Body,
                footer);
            return sb.ToString();
        }
    }
}
