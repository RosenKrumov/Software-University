using System;

class FourDigitNumber
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int a = n / 1000;
        int b = (n / 100) % 10;
        int c = (n / 10) % 10;
        int d = (n % 10);
        Console.WriteLine(a+b+c+d);
        Console.WriteLine(d + "" + c + "" + b + "" + a);
        Console.WriteLine(d + "" + a + "" + b + "" + c);
        Console.WriteLine(a + "" + c + "" + b + "" + d);

    }
}