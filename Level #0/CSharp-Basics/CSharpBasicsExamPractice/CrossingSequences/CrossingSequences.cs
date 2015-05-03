using System;
using System.Numerics;
using System.Collections.Generic;

class CrossingSequences
{
    static void Main()
    {
        int t1 = int.Parse(Console.ReadLine());
        int t2 = int.Parse(Console.ReadLine());
        int t3 = int.Parse(Console.ReadLine());
        int s1 = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        int spiralNum = s1;
        int tribonacciNum = 0;
        int incrementer = step;
        List<BigInteger> spiralNums = new List<BigInteger>();
        List<BigInteger> tribonacciNums = new List<BigInteger>();
        spiralNums.Add(s1);
        tribonacciNums.Add(t1);
        tribonacciNums.Add(t2);
        tribonacciNums.Add(t3);
        while (s1 <= 1000000 || t3 <= 1000000)
        {
            for (int i = 0; i < 2; i++)
            {

                spiralNum += step;
                s1 = spiralNum;
                spiralNums.Add(s1);
            }
            step += incrementer;

            tribonacciNum = t1 + t2 + t3;
            t1 = t2;
            t2 = t3;
            t3 = tribonacciNum;
            tribonacciNums.Add(t3);

            for (int i = 0; i < spiralNums.Count - 1; i++)
            {
                for (int j = 0; j < tribonacciNums.Count - 1; j++)
                {
                    if (spiralNums[i] < tribonacciNums[j])
                    {
                        break;
                    }
                    if (spiralNums[i] == tribonacciNums[j])
                    {
                        Console.WriteLine(spiralNums[i]);
                        return;
                    }
                }
            }
        }

        Console.WriteLine("No");
    }
}