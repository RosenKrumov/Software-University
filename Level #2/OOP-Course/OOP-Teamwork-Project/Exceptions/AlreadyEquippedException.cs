namespace TeamworkProject.Exceptions
{
    using System;

    public class AlreadyEquippedException : ApplicationException
    {
        public AlreadyEquippedException(string message)
            : base(message)
        {
        }
    }
}