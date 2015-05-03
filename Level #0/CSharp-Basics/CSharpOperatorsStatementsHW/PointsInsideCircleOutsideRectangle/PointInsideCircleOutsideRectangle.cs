using System;

class PointsInsideCircleOutsideRectangle
{
    static void Main()
    {
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());
        double centerX = 1.0;
        double centerY = 1.0;
        double radius = 1.5;
        bool isInCircle = ((x - centerX) * (x - centerX) + (y - centerY) * (y - centerY) <= radius * radius);
        if(isInCircle && y > 1)
        {
            Console.WriteLine("yes");
        }
        else
        {
            Console.WriteLine("no");
        }
    }
}