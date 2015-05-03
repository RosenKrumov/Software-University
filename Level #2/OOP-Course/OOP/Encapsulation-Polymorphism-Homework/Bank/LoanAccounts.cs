namespace Bank
{
    using System;

    class LoanAccounts : Accounts
    {
        public LoanAccounts(Customer customer, decimal balance, double interestRate)
            : base(customer, balance, interestRate) { }

        public override void DepositMoney(decimal amount)
        {
            this.Balance += amount;
            Console.WriteLine("New balance is: {0}", this.Balance);
        }
        public override decimal CalculateInterest(decimal money, int months)
        {
            if ((months <= 3 && this.Customer == Customer.Individuals) ||
                (months <= 2 && this.Customer == Customer.Companies))
            {
                throw new InvalidOperationException
                    ("If customers are individuals months should be greater than 3," + 
                "if customers are companies, months should be greater than 2");
            }
            double interestForPeriod = 1 + this.InterestRate * months;
            double interest = (double)money * interestForPeriod;
            decimal decInterest = (decimal)interest;
            return decInterest;
        }
    }
}