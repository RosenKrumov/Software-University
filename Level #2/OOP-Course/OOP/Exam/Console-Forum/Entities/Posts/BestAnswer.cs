using System.Collections.Generic;

namespace ConsoleForum.Entities.Posts
{
    using Contracts;

    public class BestAnswer : Answer
    {
        public BestAnswer(int id, string body, IUser author) 
            : base(id, body, author)
        {
            BestAnswers = new List<IAnswer>();
        }

        public static IList<IAnswer> BestAnswers { get; set; }

        public override string ToString()
        {
            string headerFooter = new string('*', 20);
            return string.Format("{0}\n{1}{0}\n", headerFooter, base.ToString());
        }
    }
}
