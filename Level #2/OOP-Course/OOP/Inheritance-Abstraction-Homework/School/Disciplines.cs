namespace School
{
    using System;
    using System.Collections.Generic;

    class Disciplines
    {
        private string name;
        private int lecturesCount;
        private IList<Student> students;
        private string details;

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Discipline name must not be empty.");
                }
                this.name = value;
            }
        }

        public int LecturesCount
        {
            get
            {
                return this.lecturesCount;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Lectures count must not be negative.");
                }
                this.lecturesCount = value;
            }
        }

        public IList<Student> Students
        {
            get
            {
                return new List<Student>(this.students);
            }

            private set
            {
                this.students = value;
            }
        }

        public string Details
        {
            get
            {
                return this.details;
            }

            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Details must not be empty.");
                }
                this.details = value;
            }
        }

        public Disciplines(string name, int lecturesCount, IList<Student> students)
        {
            this.Name = name;
            this.LecturesCount = lecturesCount;
            this.Students = students;
        }

        public Disciplines(string name, int lecturesCount, IList<Student> students, string details)
            : this(name, lecturesCount, students)
        {
            this.Details = details;
        }
    }
}
