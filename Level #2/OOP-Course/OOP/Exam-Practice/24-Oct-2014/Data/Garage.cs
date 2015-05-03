namespace Estates.Data
{
    using Interfaces;

    public class Garage : Estate, IGarage
    {
        private int width;
        private int height;

        public Garage(string name, EstateType type, double area, string location, bool isFurnished, int width, int height) 
            : base(name, type, area, location, isFurnished)
        {
            this.Width = width;
            this.Height = height;
        }

        public Garage(EstateType type)
            : base(type)
        {
        }

        public int Width
        {
            get { return this.width; }
            set
            {
                this.width = value;
                //TODO validation
            }
        }

        public int Height
        {
            get { return this.height; }
            set 
            { 
                this.height = value;
                //TODO validation
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Width: {0}, Height: {1}", this.Width, this.Height);
        }
    }
}
