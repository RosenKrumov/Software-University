using System.ServiceModel;

namespace CalcDistanceService
{
    [ServiceContract]
    public interface ICalculateDistance
    {
        [OperationContract]
        double CalculateDistance(Point startPoint, Point endPoint);
    }
}
