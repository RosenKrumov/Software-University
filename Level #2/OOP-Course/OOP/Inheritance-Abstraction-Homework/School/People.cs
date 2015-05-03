namespace School
{
    using System;

    abstract class People
    {
        private string name;
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
                    throw new ArgumentNullException("Name must not be empty.");
                }
                if (value.Length < 2)
                {
                    throw new ArgumentException("Name length must be greater than 1");
                }
                this.name = value;
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

        public People(string name)
        {
            this.Name = name;
        }

        public People(string name, string details)
            : this(name)
        {
            this.Details = details;
        }
    }
}
