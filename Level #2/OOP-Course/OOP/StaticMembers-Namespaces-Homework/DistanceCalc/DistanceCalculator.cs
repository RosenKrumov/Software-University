using System;

static class DistanceCalculator
{
    public static double CalcDistance(Point3D point1, Point3D point2)
    {
        double deltaX = point2.PointX - point1.PointX;
        double deltaY = point2.PointY - point1.PointY;
        double deltaZ = point2.PointZ - point1.PointZ;
        double distance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2) + Math.Pow(deltaZ, 2));
        return distance;
    }   
}