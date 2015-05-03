using System;

class ThirdDigit7
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int thirdDigit = (n / 100) % 10;
        if (thirdDigit == 7)
        {
            Console.WriteLine("True");
        }
        else
        {
            Console.WriteLine("False");
        }
    }
}