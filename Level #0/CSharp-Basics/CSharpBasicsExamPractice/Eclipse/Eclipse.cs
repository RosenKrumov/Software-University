using System;
    
class Eclipse
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        
        Console.Write(" ");
        Console.Write(new string('*', 2 * n - 2));
        Console.Write(new string(' ', n + 1));
        Console.WriteLine(new string('*', 2 * n - 2));

        for (int i = 1; i < n / 2; i++)
        {
            Console.Write("*");
            Console.Write(new string('/', 2 * n - 2));
            Console.Write("*");
            Console.Write(new string(' ', n - 1));
            Console.Write("*");
            Console.Write(new string('/', 2 * n - 2));
            Console.WriteLine("*");
        }

        Console.Write("*");
        Console.Write(new string('/', 2 * n - 2));
        Console.Write("*");
        Console.Write(new string('-', n - 1));
        Console.Write("*");
        Console.Write(new string('/', 2 * n - 2));
        Console.WriteLine("*");

        for (int i = n/2 + 2; i < n; i++)
        {
            Console.Write("*");
            Console.Write(new string('/', 2 * n - 2));
            Console.Write("*");
            Console.Write(new string(' ', n - 1));
            Console.Write("*");
            Console.Write(new string('/', 2 * n - 2));
            Console.WriteLine("*");            
        }

        Console.Write(" ");
        Console.Write(new string('*', 2 * n - 2));
        Console.Write(new string(' ', n + 1));
        Console.WriteLine(new string('*', 2 * n - 2));
    }
}