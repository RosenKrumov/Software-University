namespace Customer
{
    using System;
    using System.Collections.Generic;

    public class Payment
    {
        private string productName;
        private decimal price;

        public Payment(string productName, decimal price)
        {
            this.ProductName = productName;
            this.Price = price;
        }

        public string ProductName
        {
            get { return this.productName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Product name must not be empty.");
                }
                this.productName = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price must be positive.");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            string output = string.Format("Product name: {0}\n" +
                                          "Price: {1}\n", this.ProductName, this.Price);
            return output;
        }
    }
}
