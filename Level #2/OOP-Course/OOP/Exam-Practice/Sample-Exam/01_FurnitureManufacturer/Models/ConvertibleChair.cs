namespace FurnitureManufacturer.Models
{
    using Interfaces;

    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private const decimal ConvertedHeight = 0.10m;
        private readonly decimal normalHeight;

        public ConvertibleChair(string model, MaterialType materialType, decimal price, decimal height, int numberOfLegs) 
            : base(model, materialType, price, height, numberOfLegs)
        {
            this.normalHeight = this.Height;
        }

        public bool IsConverted { get; private set; }

        public void Convert()
        {
            if (this.IsConverted)
            {
                this.Height = this.normalHeight;
                this.IsConverted = false;
            }
            else
            {
                this.Height = ConvertedHeight;
                this.IsConverted = true;
            }
        }

        public override string ToString()
        {
            return base.ToString() +
                   string.Format(", State: {0}", this.IsConverted ? "Converted" : "Normal");
        }
    }
}
