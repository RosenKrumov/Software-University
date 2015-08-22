using System;

namespace CalcDistanceService
{
    public class CalculateDistanceService : ICalculateDistance
    {
        public double CalculateDistance(Point startPoint, Point endPoint)
        {
            var distance = Math.Sqrt(Math.Pow(endPoint.X - startPoint.X, 2) + Math.Pow(endPoint.Y - startPoint.Y, 2));
            return distance;
        }
    }
}
