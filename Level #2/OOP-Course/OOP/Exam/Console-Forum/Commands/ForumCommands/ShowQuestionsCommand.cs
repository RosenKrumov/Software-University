using System.Linq;
using ConsoleForum.Contracts;

namespace ConsoleForum.Commands
{
    public class ShowQuestionsCommand : AbstractCommand
    {
        public ShowQuestionsCommand(IForum forum) 
            : base(forum)
        {
        }

        public override void Execute()
        {
            var questions = this.Forum.Questions;
            
            if (questions.Any())
            {
                questions
                    .ToList()
                    .ForEach(q => this.Forum.Output.Append(q.ToString()));
            }
            else
            {
                throw new CommandException(Messages.NoQuestions);
            }
        }
    }
}
