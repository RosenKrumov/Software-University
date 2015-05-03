namespace School
{
    using System;

    class Student : People
    {
        private int uniqueClassNum;

        public int UniqueClassNum
        {
            get
            {
                return this.uniqueClassNum;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Class number must be positive.");
                }
                this.uniqueClassNum = value;
            }
        }

        public Student(string name, int uniqueClassNum, string details)
            : base(name, details)
        {
            this.UniqueClassNum = uniqueClassNum;
        }

        public Student(string name, int uniqueClassNum)
            : base(name)
        {
            this.UniqueClassNum = uniqueClassNum;
        }
    }
}
