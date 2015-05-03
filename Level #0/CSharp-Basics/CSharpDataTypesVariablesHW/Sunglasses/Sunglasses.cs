using System;

class Sunglasses
{
    static void Main()
    {
        
        int N = int.Parse(Console.ReadLine());
        Console.Write(new string('*', 2 * N));
        Console.Write(new string(' ', N));
        Console.Write(new string('*', 2 * N));
        Console.WriteLine();

        for (int i = 1; i <= N / 2 - 0.5 ; i++)
        {
            Console.Write('*');
            Console.Write(new string('/', 2 * N - 2));
            Console.Write('*');
            Console.Write(new string(' ', N));
            Console.Write('*');
            Console.Write(new string('/', 2 * N - 2));
            Console.Write('*');
            Console.WriteLine();

        }
            
        Console.Write('*');
        Console.Write(new string('/', 2 * N - 2));
        Console.Write('*');
        Console.Write(new string('|', N));
        Console.Write('*');
        Console.Write(new string('/', 2 * N - 2));
        Console.Write('*');
        Console.WriteLine();

        for (double i = N / 2 - 0.5; i <= N - 3; i++)
        {
            Console.Write('*');
            Console.Write(new string('/', 2 * N - 2));
            Console.Write('*');
            Console.Write(new string(' ', N));
            Console.Write('*');
            Console.Write(new string('/', 2 * N - 2));
            Console.Write('*');
            Console.WriteLine();

        }
            
        Console.Write(new string('*', 2 * N));
        Console.Write(new string(' ', N));
        Console.Write(new string('*', 2 * N));
           
    }
}