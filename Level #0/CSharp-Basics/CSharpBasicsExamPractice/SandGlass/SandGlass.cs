using System;

class SandGlass
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0, asterisks = n; i <= n / 2; i++, asterisks -= 2)
        {
            Console.Write(new string('.', i));
            Console.Write(new string('*', asterisks));
            Console.WriteLine(new string('.', i));
        }
        for (int i = n / 2 + 2, asterisks = 3; i <= n; i++, asterisks += 2)
        {
            Console.Write(new string('.', n - i));
            Console.Write(new string('*', asterisks));
            Console.WriteLine(new string('.', n - i));
        }
    }
}