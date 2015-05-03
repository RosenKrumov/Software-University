using System;
using System.Numerics;

class CalculateCombination
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        int c = n - k;
        BigInteger nFact = 1;
        BigInteger kFact = 1;
        BigInteger cFact = 1;
        BigInteger sum = 0;

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
            if (c <= 1)
            {
                cFact *= 1;
            }
            else
            {
                cFact *= c;
                c--;
            }
        }

        sum = nFact / (kFact * cFact);
        Console.WriteLine(sum);

    }
}