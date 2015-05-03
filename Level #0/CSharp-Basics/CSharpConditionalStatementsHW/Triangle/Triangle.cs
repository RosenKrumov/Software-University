using System;

class Triangle
{
    static void Main()
    {
        double aX = double.Parse(Console.ReadLine());
        double aY = double.Parse(Console.ReadLine());
        double bX = double.Parse(Console.ReadLine());
        double bY = double.Parse(Console.ReadLine());
        double cX = double.Parse(Console.ReadLine());
        double cY = double.Parse(Console.ReadLine());

        double a = Math.Sqrt((bX - aX)*(bX - aX) + (bY - aY)*(bY-aY));
        double b = Math.Sqrt((cX - bX) * (cX - bX) + (cY - bY) * (cY - bY));
        double c = Math.Sqrt((cX - aX) * (cX - aX) + (cY - aY) * (cY - aY));

        if ((a + b > c) && (a + c > b) && (b + c > a))
        {
            Console.WriteLine("Yes");
            double p = (a + b + c) / 2.0;
            double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            Console.WriteLine("{0:F2}", area);
        }

        else
        {
            Console.WriteLine("No");
            Console.WriteLine("{0:F2}", a);
        }


        
    }
}