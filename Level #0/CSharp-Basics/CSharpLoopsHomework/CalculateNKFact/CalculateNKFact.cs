using System;
using System.Numerics;

class CalculateNKFact
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        BigInteger sum = 0;
        BigInteger nFact = 1;
        BigInteger kFact = 1;

        while (n > 1)
        {
            nFact *= n;
            n--;
            if (k <= 1)
            {
                kFact *= 1;
            }
            else
            {
                kFact *= k;
                k--;
            }
        }

        sum = nFact / kFact;
        Console.WriteLine(sum);
    }
}