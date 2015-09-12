namespace CollectionOfProducts
{
    using System;

    public class ProjectMain
    {
        public static void Main()
        {
            var products = new CollectionOfProducts();
            var product = new Product()
            {
                Id = 1,
                Price = 12,
                Supplier = "pesho",
                Title = "gosho"
            };
            var product1 = new Product()
            {
                Id = 2,
                Price = 14,
                Supplier = "Kiko",
                Title = "Pesho"
            };
            products.AddProduct(product);
            products.AddProduct(product1);
            var found = products.FindProducts(12, 14);
            Console.WriteLine(string.Join(", ", found));
        }
    }
}
