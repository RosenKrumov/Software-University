namespace InterestCalculator
{
    using System;

    class TestInterestCalculator
    {
        public static decimal GetSimpleInterest(decimal sum, double interest, int years)
        {
            double total = (double)sum * (1 + (interest / 100) * years);
            return (decimal)total;
        }

        public static decimal GetCompoundInterest(decimal sum, double interest, int years)
        {
            double total = (double)sum * (double)Math.Pow((double)(1 + (interest / 100) / 12), 12 * years);
            return (decimal)total;
        }

        static void Main()
        {
            var simpleInterest = new InterestCalculator(500m, 5.6, GetCompoundInterest, 10);
            Console.WriteLine(simpleInterest);

            var compoundInterest = new InterestCalculator(2500m, 7.2, GetSimpleInterest, 15);
            Console.WriteLine(compoundInterest);
        }
    }
}
