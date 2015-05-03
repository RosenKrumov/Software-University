using System;

class QuadraticEcuation
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        double D = b * b - 4 * a * c;
        double x1Nominator = -b + (Math.Sqrt(D));
        double x1Denominator = 2 * a;
        double x2Nominator = -b - (Math.Sqrt(D));
        double x2Denominator = 2 * a;
        double x1 = x1Nominator / x1Denominator;
        double x2 = x2Nominator / x2Denominator;
        if (D < 0)
        {
            Console.WriteLine("No real roots");
            return;
        }
        else if (D == 0)
        {
            Console.WriteLine("x1 = x2 = {0}", x1);
        }
        else
        {
            Console.WriteLine("x1 = {0};", x2);
            Console.WriteLine("x2 = {0};", x1);
        }
    }
}