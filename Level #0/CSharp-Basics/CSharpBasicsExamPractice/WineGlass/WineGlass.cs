using System;

class WineGlass
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0, asterisks = n - 2; i < n / 2; i++, asterisks -= 2)
        {
            Console.Write(new string('.', i));
            Console.Write("\\");
            Console.Write(new string('*', asterisks));
            Console.Write("/");
            Console.WriteLine(new string('.', i));
        }

        if (n < 12)
        {
            for (int i = n / 2 + 1; i < n; i++)
            {
                Console.Write(new string('.', n / 2 - 1));
                Console.Write("||");
                Console.WriteLine(new string('.', n / 2 - 1));
            }
            Console.WriteLine(new string('-', n));    
        }

        else if (n >= 12)
        {
            for (int i = n / 2 + 1; i < n - 1; i++)
            {
                Console.Write(new string('.', n / 2 - 1));
                Console.Write("||");
                Console.WriteLine(new string('.', n / 2 - 1));                
            }
            Console.WriteLine(new string('-', n));
            Console.WriteLine(new string('-', n));    
        }

        
    }
}