using System;

class FirTree
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 1, asterisks = 1; i < n; i++, asterisks += 2)
        {
            Console.Write(new string('.', n - i - 1));
            Console.Write(new string('*', asterisks));
            Console.WriteLine(new string('.', n - i - 1));
        }

            Console.Write(new string('.', n - 2));
            Console.Write("*");
            Console.WriteLine(new string('.', n - 2));            
        

    }
}