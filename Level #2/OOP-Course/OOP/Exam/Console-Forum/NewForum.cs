using System.Collections.Generic;
using ConsoleForum.Contracts;

namespace ConsoleForum
{
    using System;
    using Commands;

    public class NewForum : Forum
    {
        protected override void ExecuteCommandLoop()
        {
            this.Output.Clear();
            var readLine = Console.ReadLine();
            if (readLine != null && readLine.ToLower() == "exit")
            {
                base.HasStarted = false;
                return;
            }
            
            var inputCommand = readLine;
            try
            {
                var command = CommandFactory.Create(inputCommand, this);
                command.Execute();
            }
            catch (CommandException ex)
            {
                this.Output.AppendLine(ex.Message);
            }
            catch (InvalidOperationException)
            {
                this.Output.AppendLine(Messages.InvalidCommand);
            }

            Console.Write(this.Output);
        }

        public static IList<IAnswer> BestAnswers { get; set; }
    }
}
