using System.Collections.Generic;
using System.Linq;

namespace ConsoleForum.Commands
{
    using System;
    using Contracts;

    public class OpenQuestionCommand : AbstractCommand
    {
        public OpenQuestionCommand(IForum forum) 
            : base(forum)
        {
        }

        public override void Execute()
        {
            var id = Convert.ToInt32(this.Data[1]);
            
            var question = this.Forum.Questions
                .ToList()
                .FindAll(q => q.Id == id);

            if (question.Count > 0)
            {
                question.ToList().ForEach(q => this.Forum.Output.Append(q.ToString()));
                this.Forum.CurrentQuestion = question.First();
            }
            else
            {
                throw new CommandException(Messages.NoQuestion);
            }
        }
    }
}
