using System;
using DistanceCalculatorClient.CalcDistanceServiceReference;

namespace DistanceCalculatorClient
{
    using CalcDistanceService;

    public class DistanceCalculatorClient
    {
        static void Main()
        {
            var service = new CalculateDistanceService(); //cannot use the disposable CalculateDistanceClient class
            var startPoint = new Point { X = 10, Y = 10 };
            var endPoint = new Point { X = 15, Y = 15 };
            var distance = service.CalculateDistance(startPoint, endPoint);
            Console.WriteLine(distance);
        }
    }
}
