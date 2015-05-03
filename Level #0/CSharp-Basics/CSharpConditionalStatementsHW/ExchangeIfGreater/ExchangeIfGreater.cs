using System;

class ExchangeIfGreater
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        if (a > b)
        {
            double c = a;
            a = b;
            b = c;
        }
        Console.WriteLine(a + " " + b );
        
    }
}