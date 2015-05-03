using System;

class NewHouse
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n / 2; i++)
        {
            Console.Write(new string('-', n/2 - i));
            Console.Write(new string('*', 2 * i + 1));
            Console.WriteLine(new string('-', n / 2 - i));
        }
        Console.WriteLine(new string('*', n));
        for (int i = 0; i < n ; i++)
        {
            Console.Write("|");
            Console.Write(new string('*', n - 2));
            Console.WriteLine("|");
        }
    }
}