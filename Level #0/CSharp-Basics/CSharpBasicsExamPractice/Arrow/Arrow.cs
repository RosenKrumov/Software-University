using System;

class Arrow
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Console.Write(new string('.', n / 2));
        Console.Write(new string('#', n));
        Console.WriteLine(new string('.', n / 2));

        for (int i = 1; i < n - 1; i++)
        {
            Console.Write(new string('.', n / 2));
            Console.Write("#");
            Console.Write(new string('.', n - 2));
            Console.Write("#");
            Console.WriteLine(new string('.', n / 2));
        }

        Console.Write(new string('#', n / 2 + 1));
        Console.Write(new string('.', n - 2));
        Console.WriteLine(new string('#', n / 2 + 1));

        for (int i = n + 1, dots = ((2 * n - 1) - 2 * (i - n) - 2); i < 2 * n - 1; i++, dots -= 2)
        {
            Console.Write(new string('.', i - n));
            Console.Write("#");
            Console.Write(new string('.', dots));
            Console.Write("#");
            Console.WriteLine(new string('.', i - n));
        }

        Console.Write(new string('.', n - 1));
        Console.Write("#");
        Console.Write(new string('.', n - 1));
    }
}