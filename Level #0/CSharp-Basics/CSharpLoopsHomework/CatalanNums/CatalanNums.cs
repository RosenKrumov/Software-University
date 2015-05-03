using System;
using System.Numerics;

class CatalanNums
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int n1 = n + 1;
        int n2 = 2 * n;
        BigInteger catalanNum = 0;
        BigInteger nFact = 1;
        BigInteger n1Fact = 1; //can't figure out better name
        BigInteger n2Fact = 1;; //can't figure out better name

        while (n > 1)
        {
            nFact *= n;
            n--;
        }

        while (n1 > 1)
        {
            n1Fact *= n1;
            n1--;
        }

        while (n2 > 1)
        {
            n2Fact *= n2;
            n2--;
        }

        catalanNum = n2Fact / (n1Fact * nFact);
        Console.WriteLine(catalanNum);
    }
}