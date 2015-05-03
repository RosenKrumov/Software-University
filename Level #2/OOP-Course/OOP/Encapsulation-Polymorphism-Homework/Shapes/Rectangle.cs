namespace Shapes
{
    using System;

    class Rectangle : BasicShape
    {
        public Rectangle(double width, double height)
            : base(width, height) { }

        public override void CalculateArea()
        {
            double area = this.Width * this.Height;
            Console.WriteLine("{0:F2}", area);
        }

        public override void CalculatePerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            Console.WriteLine("{0:F2}", perimeter);
        }
    }
}
