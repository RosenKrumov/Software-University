namespace Bank
{
    interface IAccount
    {
        void DepositMoney(decimal amount);

        decimal CalculateInterest(decimal money, int months);
    }
}
