using System;

class PointInCircle
{
    static void Main()
    {
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());
        double centerX = 0.0;
        double centerY = 0.0;
        double radius = 2.0;
        if ((x - centerX)*(x - centerX) + (y - centerY)*(y = centerY) <= radius*radius)
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine("false");
        }
    }
}