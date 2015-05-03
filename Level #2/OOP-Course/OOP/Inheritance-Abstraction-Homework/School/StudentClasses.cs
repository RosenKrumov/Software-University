namespace School
{
    using System;
    using System.Collections.Generic;

    class StudentClasses
    {
        private string uniqueId;
        private IList<Teacher> teachers;
        private string details;

        public string UniqueId
        {
            get
            {
                return this.uniqueId;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Unique ID must not be empty.");
                }
                this.uniqueId = value;
            }
        }

        public IList<Teacher> Teachers
        {
            get
            {
                return new List<Teacher>(this.teachers);
            }

            private set
            {
                this.teachers = value;
            }
        }

        public string Details
        {
            get
            {
                return this.details;
            }

            private set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Details must not be empty.");
                }
                this.details = value;
            }
        }

        public StudentClasses(string uniqueId, IList<Teacher> teachers)
        {
            this.UniqueId = uniqueId;
            this.Teachers = teachers;
        }

        public StudentClasses(string uniqueId, IList<Teacher> teachers, string details)
            : this(uniqueId, teachers)
        {
            this.Details = details;
        }


    }
}
