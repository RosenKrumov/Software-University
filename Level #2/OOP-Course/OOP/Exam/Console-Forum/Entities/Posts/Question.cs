using System;
using System.Linq;
using System.Text;

namespace ConsoleForum.Entities.Posts
{
    using System.Collections.Generic;
    using Contracts;

    public class Question : IQuestion
    {
        private int id;
        private string body;
        private string title;

        public Question(int id, string body, IUser author, string title)
        {
            this.Id = id;
            this.Body = body;
            this.Author = author;
            this.Title = title;
            this.Answers = new List<IAnswer>();
        }

        public int Id
        {
            get { return this.id; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Id must be positive value.");
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
                    throw new ArgumentException("Question body must not be empty.");
                }
                this.body = value;
            }
        }

        public IUser Author { get; set; }

        public string Title
        {
            get { return this.title; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Question title must not be empty.");
                }
                this.title = value;
            }
        }

        public IList<IAnswer> Answers { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            string footer = new string('=', 20);
            sb.AppendFormat(
                "[ Question ID: {0} ]\n" +
                "Posted by: {1}\n" +
                "Question Title: {2}\n" +
                "Question Body: {3}\n" +
                "{4}\n",
                this.Id,
                this.Author.Username,
                this.Title,
                this.Body,
                footer);
            if (this.Answers.Count > 0)
            {
                sb.AppendLine("Answers:");
                    foreach (var answer in this.Answers)
                    {
                        if (answer is BestAnswer)
                        {
                            var bestAnswer = answer as BestAnswer;
                            var output = bestAnswer.ToString();
                            sb.AppendLine(output);
                        }
                    }
                foreach (var answer in this.Answers)
                {
                    if (BestAnswer.BestAnswers != null && !BestAnswer.BestAnswers.Contains(answer))
                    {
                        sb.AppendLine(answer.ToString());
                    }
                }
            }
            else
            {
                sb.AppendLine("No answers");
            }

            return sb.ToString();
        }
    }
}