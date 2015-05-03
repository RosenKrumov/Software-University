using System;

class TelerikLogo
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 1, dots = 3 * n - 2 - n / 2 - n / 2 - 2; i <= n / 2 + 1; i++, dots -= 2)
        {
            Console.Write(new string('.', n / 2 - i + 1));

            if (i > 1)
            {
                Console.Write("*");
                Console.Write(new string('.', 2 * i - 3));
                Console.Write("*");
            }

            else if (i == 1)
            {
                Console.Write("*");
            }

            Console.Write(new string('.', dots));

            if (i > 1)
            {
                Console.Write("*");
                Console.Write(new string('.', 2 * i - 3));
                Console.Write("*");
            }

            else if (i == 1)
            {
                Console.Write("*");
            }

            Console.WriteLine(new string('.', n / 2 - i + 1));
        }

        for (int i = 0, dots = n, dotsMid = n - 4; i < 3 * n - 2 - 2 * n + 1 - n / 2 - 1; i++, dots ++, dotsMid -= 2)
        {
            Console.Write(new string('.', dots));
            Console.Write("*");
            Console.Write(new string('.', dotsMid));
            Console.Write("*");
            Console.WriteLine(new string('.', dots));
        }

        for (int i = 0; i < n; i++)
        {
            if (i > 0)
            {
                Console.Write(new string('.', (3 * n - 2 - 2 - (2 * i - 1)) / 2));
                Console.Write("*");
                Console.Write(new string('.', 2 * i - 1));
                Console.Write("*");
                Console.WriteLine(new string('.', (3 * n - 2 - 2 - (2 * i - 1)) / 2));
            }

            else if (i == 0)
            {
                Console.Write(new string('.', (3 * n - 3) / 2));
                Console.Write("*");
                Console.WriteLine(new string('.', (3 * n - 3) / 2));
            }

        }

        for (int i = 0, dotsEnd = n / 2 + 1, dots = 3 * n - 2 - 2 - 2 * dotsEnd; i < n - 2; i++, dots -= 2, dotsEnd++)
        {
                Console.Write(new string('.', dotsEnd));
                Console.Write("*");
                Console.Write(new string('.', dots));
                Console.Write("*");
                Console.WriteLine(new string('.', dotsEnd));    
        }

        Console.Write(new string('.', (3 * n - 3) / 2));
        Console.Write("*");
        Console.WriteLine(new string('.', (3 * n - 3) / 2));
    }
}