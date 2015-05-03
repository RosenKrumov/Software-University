namespace CompanyHierarchy
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    class Manager : Employee, IManager
    {
        private List<Employee> employees;

        public List<Employee> Employees
        {
            get
            {
                return new List<Employee>(this.employees);
            }
            private set
            {
                this.employees = value;
            }
        }

        public Manager(int id, string firstName, string lastName, decimal salary, Department department, List<Employee> employees)
            : base(id, firstName, lastName, salary, department)
        {
            this.Employees = employees;
        }

        public override string ToString()
        {
            string output = "Employees:\n";
            foreach (var employee in this.Employees)
            {
                output += employee.ToString();
                output += "\n";
            }
            return base.ToString() + output;
        }
    }
}
