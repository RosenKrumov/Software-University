using System;
using System.Numerics;

class TrailingZeroes
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int trailingZeroes = 0;
        int divisor = 5;

        while (n / divisor >= 1)
        {
            trailingZeroes += n / divisor;
            divisor *= 5;
        }

        Console.WriteLine(trailingZeroes);
    }
}