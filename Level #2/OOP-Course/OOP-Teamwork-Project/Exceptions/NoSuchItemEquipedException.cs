namespace TeamworkProject.Exceptions
{
    using System;

    public class NoSuchItemEquipedException : ApplicationException
    {
        public NoSuchItemEquipedException(string message)
            : base(message)
        {
        }
    }
}