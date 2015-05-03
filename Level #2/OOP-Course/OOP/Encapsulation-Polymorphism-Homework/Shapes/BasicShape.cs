namespace Shapes
{
    using System;

    abstract class BasicShape : IShape
    {
        private double width;
        private double height;

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

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Height must be positive.");
                }
                this.height = value;
            }
        }

        public BasicShape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public BasicShape(double width)
        {
            this.Width = width;
        }

        public abstract void CalculateArea();

        public abstract void CalculatePerimeter();
    }
}
