namespace Bank
{
    using System;

    class TestBankSystem
    {
        static void Main()
        {
            DepositAccounts depositAcc = new DepositAccounts(Customer.Individuals, 10000m, 2.84);
            Console.WriteLine("Your balance is: {0}", depositAcc.Balance);
            depositAcc.DepositMoney(100m);
            depositAcc.WithdrawMoney(1000m);
            Console.WriteLine();

            MortgageAccounts mortgageAcc = new MortgageAccounts(Customer.Companies, 9500m, 3.15);
            Console.WriteLine("Your balance is: {0}", mortgageAcc.Balance);
            mortgageAcc.DepositMoney(2500m);
            Console.WriteLine("Interest is: {0}", mortgageAcc.CalculateInterest(1000, 24)); //You can test another cases.
            Console.WriteLine();

            LoanAccounts loanAcc = new LoanAccounts(Customer.Individuals, 3400m, 2.2);
            Console.WriteLine("Your balance is: {0}", loanAcc.Balance);
            loanAcc.DepositMoney(2400m);
            Console.WriteLine("Interest is: {0}", loanAcc.CalculateInterest(1300, 8));
        }
    }
}
