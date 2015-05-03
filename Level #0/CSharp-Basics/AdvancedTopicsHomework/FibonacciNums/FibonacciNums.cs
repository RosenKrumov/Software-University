using System;

    class FibonacciNums
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Fib(n));
        }
        static int Fib (int n1)
        {
            int n2 = 0;
            if (n1 == 0 || n1 == 1)
            {
                n2 = 1;
            }
            else
            {
                int a = 1;
                int b = 1;
               
                for (int i = 0; i < n1 - 1; i++)
                {
                    n2 = a + b;
                    a = b;
                    b = n2;
                }
                n2 = b;
            }
            return n2;
        }
    }