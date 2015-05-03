using System;
using System.Linq;

class CalculateGCD
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int[] divisors = new int[Math.Max(a,b)];
        for (int i = 1; i <= Math.Max(a,b); i++)
        {
            if (a % i == 0 && b % i == 0)
            {
                divisors[i - 1] = i;
            }
        }

        Console.WriteLine(divisors.Max());
    }
}