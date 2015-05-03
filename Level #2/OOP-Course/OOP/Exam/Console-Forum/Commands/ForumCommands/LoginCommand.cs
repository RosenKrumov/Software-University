using ConsoleForum.Utility;

namespace ConsoleForum.Commands
{
    using System.Linq;
    using Contracts;

    public class LoginCommand : AbstractCommand
    {
        public LoginCommand(IForum forum) 
            : base(forum)
        {
        }

        public override void Execute()
        {
            var users = this.Forum.Users;
            var username = this.Data[1];
            var password = PasswordUtility.Hash(this.Data[2]);

            var user = users
                .FirstOrDefault(u => u.Username == username && u.Password == password);
            
            if (this.Forum.CurrentUser != null)
            {
                throw new CommandException(Messages.AlreadyLoggedIn);
            }

            if (user != null)
            {
                this.Forum.Output.AppendLine(string.Format(Messages.LoginSuccess, username));
                this.Forum.CurrentUser = user;
            }
            else
            {
                throw new CommandException(Messages.InvalidLoginDetails);
            }
        }
    }
}
