using System;

class House
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Console.Write(new string('.', n / 2));
        Console.Write("*");
        Console.WriteLine(new string('.', n / 2));

        for (int i = 1; i < n / 2; i++)
        {
            Console.Write(new string('.', n / 2 - i));
            Console.Write("*");
            Console.Write(new string('.', 2 * i - 1));
            Console.Write("*");
            Console.WriteLine(new string('.', n / 2 - i));
        }

        Console.WriteLine(new string('*', n));

        for (int i = n / 2 + 2; i < n; i++)
        {
            Console.Write(new string('.', n / 4));
            Console.Write("*");
            if ((n - n/2 - 2) % 2 == 1)
            {
                Console.Write(new string('.', n - n / 2 - 2));                
            }
            else
            {
                Console.Write(new string('.', n - n / 2 - 1));
            }

            Console.Write("*");
            Console.WriteLine(new string('.', n / 4));
        }

        Console.Write(new string('.', n / 4));

        switch (n)
        {
            case 11:
            case 15:
            case 19:
            case 23:
            case 27:
            case 31:
            case 35:
            case 39:
            case 43:
            case 47:
                Console.Write(new string('*', n - n / 2 + 1));
                break;
            default:
                Console.Write(new string('*', n - n / 2));
                break;
        }

                
             
        

        Console.WriteLine(new string('.', n / 4));
    }
}

