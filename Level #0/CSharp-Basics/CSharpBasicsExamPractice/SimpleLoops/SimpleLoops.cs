using System;
using System.Numerics;

class SimpleLoops
    {
        static void Main()
        {
            BigInteger t1 = new BigInteger(int.Parse(Console.ReadLine()));
            BigInteger t2 = new BigInteger(int.Parse(Console.ReadLine()));
            BigInteger t3 = new BigInteger(int.Parse(Console.ReadLine()));
            int n = int.Parse(Console.ReadLine());

            if (n == 1)
            {
                Console.WriteLine(t1);
            }
            else if (n == 2)
            {
                Console.WriteLine(t2);
            }
            else if (n == 3)
            {
                Console.WriteLine(t3);
            }
            else
            {
                for (int i = 4; i <= n; i++)
                {
                    BigInteger tNew = t1 + t2 + t3;
                    t1 = t2;
                    t2 = t3;
                    t3 = tNew;
                }

                Console.WriteLine(t3);
            }
        }
    }