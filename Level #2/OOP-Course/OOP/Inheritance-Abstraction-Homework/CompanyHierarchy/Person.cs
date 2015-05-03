namespace CompanyHierarchy
{
    using System;
    using Interfaces;

    class Person : IPerson
    {
        private int id;
        private string firstName;
        private string lastName;

        public int Id
        {
            get
            {
                return this.id;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("ID must be positive");
                }
                this.id = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name must not be empty.");
                }
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name must not be empty.");
                }
            }
        }

        public Person(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public override string ToString()
        {
            return string.Format("Person ID: {0}\nPerson first name: {1}\nPerson last name: {2}\n", this.Id, this.FirstName, this.LastName);
        }
    }
}
