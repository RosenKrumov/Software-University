using System;

class TheExplorer
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Console.Write(new string('_', n/2));
        Console.Write("*");
        Console.WriteLine(new string('_', n / 2));

        for (int i = 1; i < n/2; i++)
        {
            Console.Write(new string('_', n/2 - i));
            Console.Write("*");
            Console.Write(new string('_', 2*i - 1));
            Console.Write("*");
            Console.WriteLine(new string('_', n/2 - i));
        }

        for (int i = n/2 + 1; i < n - 1; i++)
        {
            Console.Write(new string('_', i - n/2 - 1));
            Console.Write("*");
            Console.Write(new string('_', n - i / 2));
            Console.Write("*");
            Console.WriteLine(new string('_', i - n / 2 - 1));
        }

        Console.Write(new string('_', n / 2));
        Console.Write("*");
        Console.WriteLine(new string('_', n / 2));
    }
}