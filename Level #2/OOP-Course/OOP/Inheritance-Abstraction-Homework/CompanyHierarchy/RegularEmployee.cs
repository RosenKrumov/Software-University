namespace CompanyHierarchy
{
    using System;

    class RegularEmployee : Employee
    {
        public RegularEmployee(int id, string firstName, string lastName, decimal salary, Department department)
            : base(id, firstName, lastName, salary, department) 
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
