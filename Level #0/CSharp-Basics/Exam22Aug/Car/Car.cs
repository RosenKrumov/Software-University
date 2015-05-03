using System;

    class Car
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Console.Write(new string('.', n));
            Console.Write(new string('*', n));
            Console.WriteLine(new string('.', n));

            for (int i = 1, dots = n; i <= n / 2; i++, dots += 2)
            {
                if (i < n / 2)
                {
                    Console.Write(new string('.', n - i));
                    Console.Write("*");
                    Console.Write(new string('.', dots));
                    Console.Write("*");
                    Console.WriteLine(new string('.', n - i));
                }
                else
                {
                    Console.Write(new string('*', n - i));
                    Console.Write("*");
                    Console.Write(new string('.', dots));
                    Console.Write("*");
                    Console.WriteLine(new string('*', n - i));
                }
            }

            for (int i = 0; i < n / 2 - 2; i++)
            {
                Console.Write("*");
                Console.Write(new string('.', 3*n - 2));
                Console.WriteLine("*");
            }

            Console.WriteLine(new string('*', 3*n));

            for (int i = n + 1; i <= 3*n/2 - 1; i++)
            {
                if (i < 3*n/2 - 1)
                {
                    Console.Write(new string('.', n / 2));
                    Console.Write("*");
                    Console.Write(new string('.', n / 2 - 1));
                    Console.Write("*");
                    Console.Write(new string('.', n - 2));
                    Console.Write("*");
                    Console.Write(new string('.', n / 2 - 1));
                    Console.Write("*");
                    Console.WriteLine(new string('.', n / 2));
                }
                else if (i == 3*n/2 - 1)
                {
                    Console.Write(new string('.', n / 2));
                    Console.Write("*");
                    Console.Write(new string('*', n / 2 - 1));
                    Console.Write("*");
                    Console.Write(new string('.', n - 2));
                    Console.Write("*");
                    Console.Write(new string('*', n / 2 - 1));
                    Console.Write("*");
                    Console.WriteLine(new string('.', n / 2));
                }
            }
        }
    }