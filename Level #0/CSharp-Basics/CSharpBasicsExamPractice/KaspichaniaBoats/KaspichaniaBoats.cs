using System;

class KaspichaniaBoats
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            Console.Write(new string('.', n - i + 1));

            if (i >= 2)
	        {
                Console.Write("*");
		        Console.Write(new string('.', i - 2));
	        }
            Console.Write("*");
            if (i >= 2)
            {
                Console.Write(new string('.', i - 2));
                Console.Write("*");
		        
	        }
            Console.WriteLine(new string('.', n - i + 1));
        }

        Console.WriteLine(new string('*', 2 * n + 1));

        for (int i = 0; i < n / 2; i++)
        {
            Console.Write(new string('.', i + 1));
            Console.Write("*");
            Console.Write(new string('.', n - 2 - i));
            Console.Write("*");
            Console.Write(new string('.', n - 2 - i));
            Console.Write("*");
            Console.WriteLine(new string('.', i + 1));
        }

        Console.Write(new string('.', n / 2 + 1));
        Console.Write(new string('*', n));
        Console.WriteLine(new string('.', n / 2 + 1));

    }
}