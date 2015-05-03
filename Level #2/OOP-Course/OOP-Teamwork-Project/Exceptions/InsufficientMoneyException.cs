namespace TeamworkProject.Exceptions
{
    using System;

    public class InsufficientMoneyException : ApplicationException
    {
        public InsufficientMoneyException(string message)
            : base(message)
        {
        }
    }
}