namespace Bank
{
    using System;

    abstract class Accounts : IAccount
    {
        private Customer customer;
        private decimal balance;
        private double interestRate;

        public Customer Customer
        {
            get { return this.customer; }
            set { this.customer = value; }
        }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Balance must be positive.");
                }
                this.balance = value;
            }
        }

        public double InterestRate
        {
            get
            {
                return this.interestRate;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Interest rate must be positive.");
                }
                this.interestRate = value;
            }
        }

        public Accounts(Customer customer, decimal balance, double interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public abstract void DepositMoney(decimal amount);

        public abstract decimal CalculateInterest(decimal money, int months);
    }
}
