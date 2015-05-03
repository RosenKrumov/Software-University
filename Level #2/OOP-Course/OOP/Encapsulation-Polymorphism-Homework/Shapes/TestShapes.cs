namespace Shapes
{
    using System;

    class TestShapes
    {
        static void Main()
        {
            Circle circle = new Circle(5.8);
            Rectangle rectangle = new Rectangle(8.2, 5);
            Triangle triangle = new Triangle(10, 10);

            BasicShape[] shapes = new BasicShape[] { circle, rectangle, triangle };

            foreach (var shape in shapes)
            {
                shape.CalculateArea();
                shape.CalculatePerimeter();
            }
        }
    }
}
