using System;

class Point
{
    public int pointX { get; set; }
    public int pointY { get; set; }
}
class PerimeterAreaPolygon
{
    static double Distance(int x1, int y1, int x2, int y2)
    {
        int distanceX = x2 - x1;
        int distanceY = y2 - y1;
        double distance = Math.Sqrt(distanceX * distanceX + distanceY * distanceY);
        return distance;
    }


    static double Perimeter(Point[] perimeter)
    {
        double p = 0;
        for (int i = 0; i < perimeter.Length - 1; i++)
        {
            p += Distance(perimeter[i].pointX, perimeter[i].pointY, perimeter[i + 1].pointX, perimeter[i + 1].pointY);
        }
        return p;

    }

    static double Area(int[,] matrix, int pointsCount)
    {
        double result = 0;
        double leftSum = 0;
        double rightSum = 0;

        for (int i = 0; i < pointsCount - 1; i++)
        {
            leftSum += (matrix[i, 0] * matrix[i + 1, 1]);
            rightSum += (matrix[i, 1] * matrix[i + 1, 0]);
        }

        result = Math.Abs((leftSum - rightSum) / 2);
        return result;
    }
    static void Main()
    {
        int pointsCount = int.Parse(Console.ReadLine());
        int[,] matrix = new int[pointsCount, 2];

        Point[] perimeter = new Point[pointsCount];

        for (int i = 0; i < pointsCount; i++)
        {
            string coordinates = Console.ReadLine();
            string[] coordinate = coordinates.Split(' ');

            perimeter[i] = new Point() { pointX = int.Parse(coordinate[0]), pointY = int.Parse(coordinate[1]) };
            matrix[i, 0] = int.Parse(coordinate[0]);
            matrix[i, 1] = int.Parse(coordinate[1]);
        }

        Console.WriteLine("perimeter = {0:F2}", Perimeter(perimeter));
        Console.WriteLine("area = {0:F2}", Area(matrix, pointsCount));
    }
}