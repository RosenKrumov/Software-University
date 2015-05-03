namespace HumanStudentWorker
{
    using System;

    class Student : Human
    {
        private string facultyNumber;

        public string FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Faculty number must not be empty.");
                }
                if (value.Length > 10 || value.Length < 5)
                {
                    throw new ArgumentOutOfRangeException("Faculty number length must be between 5 and 10.");
                }
                this.facultyNumber = value;
            }
        }

        public Student (string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public override string ToString()
        {
            return base.ToString() +
                string.Format("Faculty number: {0}\n", this.FacultyNumber);
        }
    }
}
