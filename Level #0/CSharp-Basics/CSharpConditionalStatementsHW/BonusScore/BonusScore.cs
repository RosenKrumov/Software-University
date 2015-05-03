using System;

class BonusScore
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());

        if (a >= 1 && a <= 3)
        {
            a *= 10;
            Console.WriteLine(a);
        }
        else if (a >= 4 && a <= 6)
        {
            a *= 100;
            Console.WriteLine(a);
        }
        else if (a >= 7 && a <= 9)
        {
            a *= 1000;
            Console.WriteLine(a);
        }

        else
        {
            Console.WriteLine("Invalid score");
        }
    }
}