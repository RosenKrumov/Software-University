using System;

class TheBiggestOf5Nums
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        double d = double.Parse(Console.ReadLine());
        double e = double.Parse(Console.ReadLine());
        if (a >= b && a >= c && a >= d && a >= e)
        {
            Console.WriteLine(a);
        }
        else if (a <= b && b >= c && b >= d && b >= e)
        {
            Console.WriteLine(b);
        }
        else if (a <= c && b <= c && d <= c && e <= c)
        {
            Console.WriteLine(c);
        }
        else if (a <= d && b <= d && c <= d && e <= d)
        {
            Console.WriteLine(d);
        }
        else if (a <= e && b <= e && c <= e && d <= e)
        {
            Console.WriteLine(e);
        }
    }
}