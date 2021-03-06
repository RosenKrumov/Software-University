﻿using System.Linq;

namespace ConsoleForum.Commands
{
    using Contracts;

    public class LogoutCommand : AbstractCommand
    {
        public LogoutCommand(IForum forum) 
            : base(forum)
        {
        }

        public override void Execute()
        {
            if (this.Forum.CurrentUser != null)
            {
                this.Forum.CurrentUser = null;
                this.Forum.Output.AppendLine(Messages.LogoutSuccess);
            }
            else
            {
                throw new CommandException(Messages.NotLogged);
            }
        }
    }
}
