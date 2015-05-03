using System;

class Trapezoid
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        
        Console.Write(new string('.', n));
        Console.WriteLine(new string('*', n));

        for (int i = 0; i < n - 1; i++)
        {
            Console.Write(new string('.', n - i - 1));
            Console.Write("*");
            Console.Write(new string('.', 2*n - (n - i - 1) - 2));
            Console.WriteLine("*");
        }

        Console.WriteLine(new string('*', 2*n));
    }
}