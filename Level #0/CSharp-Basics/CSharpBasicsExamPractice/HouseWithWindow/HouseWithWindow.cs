using System;

class HouseWithWindow
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Console.Write(new string('.', n - 1));
        Console.Write("*");
        Console.WriteLine(new string('.', n - 1));
        
        for (int i = 1; i < n; i++)
        {
            Console.Write(new string('.', n - i - 1));
            Console.Write("*");
            Console.Write(new string('.', 2 * i - 1));
            Console.Write("*");
            Console.WriteLine(new string('.', n - i - 1));
        }

        Console.WriteLine(new string('*', 2 * n - 1));

        for (int i = 0; i < n / 4; i++)
        {
            Console.Write("*");
            Console.Write(new string('.', 2 * n - 3));
            Console.WriteLine("*");
        }

        for (int i = 0; i < n / 2; i++)
        {
            Console.Write("*");
            Console.Write(new string('.', n / 2));
            Console.Write(new string('*', n - 3));
            Console.Write(new string('.', n / 2));
            Console.WriteLine("*");
        }

        for (int i = 0; i < n / 4; i++)
        {
            Console.Write("*");
            Console.Write(new string('.', 2 * n - 3));
            Console.WriteLine("*");
        }

        Console.WriteLine(new string('*', 2 * n - 1));
    }
}