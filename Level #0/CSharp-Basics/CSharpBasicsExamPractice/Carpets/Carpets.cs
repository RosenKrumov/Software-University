using System;

class Carpets
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0, dots = (n - 2) / 2; i < n / 2; i++, dots--)
        {
                Console.Write(new string('.', dots));
                Console.Write("/");
                Console.Write(new string(' ', (n - 2 * dots - 2) / 2));
                Console.Write(new string(' ', (n - 2 * dots - 2) / 2));
                Console.Write("\\");
                Console.WriteLine(new string('.', dots));                
        }
    }
}