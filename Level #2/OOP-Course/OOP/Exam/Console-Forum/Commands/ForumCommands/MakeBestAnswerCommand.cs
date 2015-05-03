using System.Linq;
using ConsoleForum.Entities.Posts;

namespace ConsoleForum.Commands
{
    using System;
    using Contracts;

    public class MakeBestAnswerCommand : AbstractCommand
    {
        public MakeBestAnswerCommand(IForum forum) 
            : base(forum)
        {
        }

        public override void Execute()
        {
            const int adminId = 1;
            var id = Convert.ToInt32(this.Data[1]);

            if (this.Forum.CurrentUser == null)
            {
                throw new CommandException(Messages.NotLogged);
            }

            if (this.Forum.CurrentQuestion == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }

            if (this.Forum.Questions.All(q => q.Id != id))
            {
                throw new CommandException(Messages.NoAnswer);
            }

            var usernameAuthor = this.Forum.CurrentQuestion.Author.Username;
            var usernameAuthorId = this.Forum.CurrentQuestion.Author.Id;
            var currentUserName = this.Forum.CurrentUser.Username;
            
            if (usernameAuthor != currentUserName && usernameAuthorId != adminId)
            {
                throw new CommandException(Messages.NoPermission);
            }

            var answer = this.Forum.CurrentQuestion.Answers.First(a => id == a.Id);

            answer = answer as BestAnswer;
            this.Forum.Output.AppendLine(string.Format(Messages.BestAnswerSuccess, id));
        }
    }
}
