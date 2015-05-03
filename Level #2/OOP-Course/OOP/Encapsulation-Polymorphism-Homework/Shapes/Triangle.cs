namespace Shapes
{
    using System;

    class Triangle : BasicShape
    {
        public Triangle(double width, double height)
            : base(width, height) { }

        public override void CalculateArea()
        {
            double area = this.Width * this.Height / 2;
            Console.WriteLine("{0:F2}", area);
        }

        public override void CalculatePerimeter()
        {
            double perimeter = 3 * this.Width;
            Console.WriteLine("{0:F2}", perimeter);
        }
    }
}
