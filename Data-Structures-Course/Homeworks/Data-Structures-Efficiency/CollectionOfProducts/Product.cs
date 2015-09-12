namespace CollectionOfProducts
{
    using System;
    using System.Text;

    public class Product : IComparable<Product>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Supplier { get; set; }
        public decimal Price { get; set; }

        public int CompareTo(Product other)
        {
            return this.Id.CompareTo(other.Id);
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(string.Format("Title: {0}", this.Title));
            output.AppendLine(string.Format("Supplier: {0}", this.Supplier));
            output.AppendLine(string.Format("Price: {0}", this.Price));

            return output.ToString();
        }
    }
}
