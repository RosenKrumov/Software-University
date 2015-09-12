namespace ShoppingCenter
{
    using System;
    using System.Text;

    public class Product : IComparable<Product>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Producer { get; set; }

        public int CompareTo(Product other)
        {
            int result = this.Name.CompareTo(other.Name);
            if (result == 0)
            {
                result = this.Producer.CompareTo(other.Producer);
            }

            if (result == 0)
            {
                result = this.Price.CompareTo(other.Price);
            }

            return result;
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output
                .Append("{")
                .Append(this.Name)
                .Append(";")
                .Append(this.Producer)
                .Append(";")
                .Append(this.Price.ToString("0.00"))
                .Append("}");

            return output.ToString();
        }
    }
}
