namespace Bank
{
    using System;

    class DepositAccounts : Accounts
    {
        public DepositAccounts(Customer customer, decimal balance, double interestRate)
            : base(customer, balance, interestRate) { }

        public override void DepositMoney(decimal amount)
        {
            this.Balance += amount;
            Console.WriteLine("New balance is: {0}", this.Balance);
        }

        public void WithdrawMoney(decimal amount)
        {
            this.Balance -= amount;
            Console.WriteLine("Money withdrawn: {0}\nNew balance is {1}", amount, this.Balance);
            this.Balance = 0;
        }

        public override decimal CalculateInterest(decimal money, int months)
        {
            if (money < 1000)
            {
                throw new InvalidOperationException("Money must be greater than 1000.");
            }
            double interestForPeriod = 1 + this.InterestRate * months;
            double interest = (double)money * interestForPeriod;
            decimal decInterest = (decimal)interest;
            return decInterest;
        }
    }
}