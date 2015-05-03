namespace CompanyHierarchy
{
    using System;
    using Interfaces;

    class Employee : Person, IEmployee
    {
        private decimal salary;
        private Department department;

        public decimal Salary
        {
            get
            {
                return this.salary;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Salary must be positive");
                }
                this.salary = value;
            }
        }

        public Department Department 
        {
            get { return this.department; } 
            set { this.department = value; } 
        }

        public Employee(int id, string firstName, string lastName, decimal salary, Department department)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
            this.Department = department;
        }

        public override string ToString()
        {
            return base.ToString() + 
                string.Format("Salary: {0}\nDepartment: {1}\n", this.Salary, this.Department);
        }
    }
}
