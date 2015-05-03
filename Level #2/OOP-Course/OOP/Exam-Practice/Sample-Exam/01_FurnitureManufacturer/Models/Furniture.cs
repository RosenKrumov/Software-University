namespace FurnitureManufacturer.Models
{
    using Interfaces;

    public abstract class Furniture : IFurniture
    {
        private readonly MaterialType materialType;
        private string model;
        private decimal price;
        private decimal height;

        protected Furniture(string model, MaterialType materialType, decimal price, decimal height)
        {
            this.Model = model;
            this.materialType = materialType;
            this.Price = price;
            this.Height = height;
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                Validators.AssertNotEmpty(value, "Model");
                Validators.AssertStringSize(value, 3, "Model");
                this.model = value;
            }
        }

        public string Material
        {
            get { return this.materialType.ToString(); }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                Validators.AssertMinValue(value, 0, "Price");
                this.price = value;
            }
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }

            protected set
            {
                Validators.AssertMinValue(value, 0, "Height");
                this.height = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}",
                this.GetType().Name, this.Model, this.Material, this.Price, this.Height);
        }
    }
}
