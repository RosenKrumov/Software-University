using System;

class FibonacciNums
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int f1 = 0;
        int f2 = 1;
        if (n == 1)
        {
            Console.WriteLine(f1);
        }
        else if (n == 2)
        {
            Console.WriteLine(f2);
        }
        else
        {
            Console.WriteLine(f1);
            Console.WriteLine(f2);
            for (int i = 0; i < n - 2; i++)
            {
                int f3 = f1 + f2;
                f1 = f2;
                f2 = f3;
                Console.WriteLine(f3);
            }
        }
    }
}