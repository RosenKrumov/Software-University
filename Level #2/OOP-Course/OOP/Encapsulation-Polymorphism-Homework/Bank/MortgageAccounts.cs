namespace Bank
{
    using System;

    class MortgageAccounts : Accounts
    {
        public MortgageAccounts(Customer customer, decimal balance, double interestRate)
            : base(customer, balance, interestRate) { }

        public override void DepositMoney(decimal amount)
        {
            this.Balance += amount;
            Console.WriteLine("New balance is: {0}", this.Balance);
        }
        public override decimal CalculateInterest(decimal money, int months)
        {
            if (months <= 6 && this.Customer == Customer.Individuals)
            {
                throw new InvalidOperationException("Months should be greater than 6 if customers are individuals.");
            }
            double interestForPeriod = 1 + this.InterestRate * months;
            double interest = (double)money * interestForPeriod;
            decimal decInterest = (decimal)interest;
            if (months <= 12 && this.Customer == Customer.Companies)
            {
                decInterest /= 2;
            }
            return decInterest;
        }
    }
}