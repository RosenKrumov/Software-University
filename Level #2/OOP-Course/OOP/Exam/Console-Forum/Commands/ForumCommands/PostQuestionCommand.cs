using System.Linq;
using ConsoleForum.Entities.Posts;

namespace ConsoleForum.Commands
{
    using System;
    using Contracts;

    public class PostQuestionCommand : AbstractCommand
    {
        public PostQuestionCommand(IForum forum) 
            : base(forum)
        {
        }

        public override void Execute()
        {
            var questions = this.Forum.Questions;
            var title = this.Data[1];
            var body = this.Data[2];

            if (this.Forum.CurrentUser == null)
            {
                throw new CommandException(Messages.NotLogged);
            }

            var id = questions.Count + 1;
            var author = this.Forum.CurrentUser;
            IQuestion question = new Question(id, body, author, title);
            this.Forum.CurrentUser.Questions.Add(question);
            this.Forum.CurrentQuestion = question;
            this.Forum.Questions.Add(question);
            this.Forum.Output.AppendLine(string.Format(Messages.PostQuestionSuccess, id));
        }
    }
}
