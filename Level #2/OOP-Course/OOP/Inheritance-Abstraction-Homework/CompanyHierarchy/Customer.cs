namespace CompanyHierarchy
{
    using System;
    using Interfaces;

    class Customer : Person, ICustomer
    {
        private decimal totalAmount;

        public decimal TotalAmount
        {
            get
            {
                return this.totalAmount;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Total amount must be positive.");
                }
                this.totalAmount = value;
            }
        }

        public Customer(int id, string firstName, string lastName, decimal totalAmount)
            : base(id, firstName, lastName)
        {
            this.TotalAmount = totalAmount;
        }

        public override string ToString()
        {
            return base.ToString() + 
                string.Format("Total amount spent: {0}", this.TotalAmount);
        }
    }
}
