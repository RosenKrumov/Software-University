using System;

    class PrimeChecker
    {
        static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            Console.WriteLine(IsPrime(n));
            
        }

        static bool IsPrime(long n1)
        {
            bool prime = true;
            
            if (n1 <= 1)
            {
                prime = false;
                return prime;
            }
            
            for (int i = 2; i <= Math.Sqrt(n1); i++)
            {
                if (n1 % i == 0)
                {
                    prime = false;
                }

            }
            return prime;
        }
    }