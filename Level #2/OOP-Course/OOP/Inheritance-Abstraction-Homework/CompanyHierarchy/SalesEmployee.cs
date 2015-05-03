namespace CompanyHierarchy
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    class SalesEmployee : RegularEmployee, ISalesEmployee
    {
        private List<Sale> sales;

        public List<Sale> Sales
        {
            get
            {
                return new List<Sale>(this.sales);
            }
            private set
            {
                this.sales = value;
            }
        }

        public SalesEmployee(int id, string firstName, string lastName, decimal salary, Department department, List<Sale> sales)
            : base(id, firstName, lastName, salary, department)
        {
            this.Sales = sales;
        }

        public override string ToString()
        {
            string output = "Sales:\n";
            foreach (var sale in this.Sales)
            {
                output += sale.ToString();
                output += "\n";
            }
            return base.ToString() + output;
        }
    }
}
