using System;

class Point3D
{
    private static readonly Point3D startingPoint = new Point3D(0, 0, 0);

    public double PointX { get; set; }
    public double PointY { get; set; }
    public double PointZ { get; set; }

    public static Point3D StartingPoint
    {
        get
        {
            return startingPoint;
        }
    }

    public Point3D(double pointX, double pointY, double pointZ)
    {
        this.PointX = pointX;
        this.PointY = pointY;
        this.PointZ = pointZ;
    }

    public override string ToString()
    {
        string result = string.Format("X: {0} \nY: {0} \nZ: {0}", this.PointX, this.PointY, this.PointZ);
        return result;
    }
}