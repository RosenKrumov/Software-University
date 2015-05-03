namespace Shapes
{
    using System;

    class Circle : BasicShape
    {
        private double width;

        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Width must be positive.");
                }
                this.width = value;
            }
        }

        public Circle(double width)
            : base(width)
        {
            this.Width = width;
        }

        public override void CalculateArea()
        {
            double area = Math.PI * Math.Pow(this.Width, 2);
            Console.WriteLine("{0:F2}", area);
        }

        public override void CalculatePerimeter()
        {
            double perimeter = 2 * Math.PI * this.Width;
            Console.WriteLine("{0:F2}", perimeter);
        }
    }
}