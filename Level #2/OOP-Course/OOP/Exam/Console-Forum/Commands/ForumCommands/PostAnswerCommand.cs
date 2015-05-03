namespace ConsoleForum.Commands
{
    using System.Collections.Generic;
    using Contracts;
    using Entities.Posts;

    public class PostAnswerCommand : AbstractCommand
    {
        public PostAnswerCommand(IForum forum) 
            : base(forum)
        {
        }

        public override void Execute()
        {
            var body = this.Data[1];

            if (this.Forum.CurrentUser == null)
            {
                throw new CommandException(Messages.NotLogged);
            }

            if (this.Forum.CurrentQuestion == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }

            var answerId = this.Forum.Answers.Count + 1;
            var user = this.Forum.CurrentUser;
            
            IAnswer answer = new Answer(answerId, body, user);
            this.Forum.CurrentQuestion.Answers.Add(answer);
            this.Forum.Answers.Add(answer);
            this.Forum.Output.AppendLine(string.Format(Messages.PostAnswerSuccess, answerId));
            BestAnswer.BestAnswers = new List<IAnswer>();
        }
    }
}
