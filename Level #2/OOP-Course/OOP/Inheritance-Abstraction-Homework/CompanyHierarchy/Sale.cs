namespace CompanyHierarchy
{
    using System;
    using Interfaces;

    class Sale : ISale
    {
        private string productName;
        private string date;
        private decimal price;

        public string ProductName
        {
            get
            {
                return this.productName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Product name must not be empty.");
                }
                this.productName = value;
            }
        }

        public string Date 
        {
            get { return this.date; }
            private set { this.date = value; }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price must be positive.");
                }
                this.price = value;
            }
        }

        public Sale(string productName, string date, decimal price)
        {
            this.ProductName = productName;
            this.Date = date;
            this.Price = price;
        }

        public override string ToString()
        {
            return string.Format("Product name: {0}\nProduct sale date: {1}\nProduct price: {2}\n", this.ProductName, this.Date, this.Price);
        }
    }
}
