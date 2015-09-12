namespace ShoppingCenter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ShoppingCenterSlow
    {
        private const string ProductAdded = "Product added";
        private const string ProductsDeleted = " products deleted";
        private const string NoProductsFound = "No products found";
        private const string IncorrectCommand = "Incorrect command";

        private readonly List<Product> products = new List<Product>();

        private string AddProduct(string name, string price, string producer)
        {
            Product product = new Product()
            {
                Name = name,
                Price = decimal.Parse(price),
                Producer = producer
            };

            this.products.Add(product);
            return ProductAdded;
        }

        private string FindProductsByName(string name)
        {
            var output = this.products
                .Where(p => p.Name == name)
                .OrderBy(p => p);

            return PrintProducts(output);
        }

        private string FindProductsByProducer(string producer)
        {
            var output = this.products
                .Where(p => p.Producer == producer)
                .OrderBy(p => p);

            return PrintProducts(output);
        }

        private string FindProductsByPriceRange(string startPrice, string endPrice)
        {
            decimal rangeStart = decimal.Parse(startPrice);
            decimal rangeEnd = decimal.Parse(endPrice);

            var output = this.products
                .Where(p => p.Price >= rangeStart && p.Price <= rangeEnd)
                .OrderBy(p => p);

            return PrintProducts(output);
        }

        private string PrintProducts(IEnumerable<Product> productsToPrint)
        {
            if (productsToPrint.Any())
            {
                var output = new StringBuilder();
                foreach (var product in productsToPrint)
                {
                    output.AppendLine(product.ToString());
                }

                string formattedProducts = output.ToString().TrimEnd();
                return formattedProducts;
            }

            return NoProductsFound;
        }

        private string DeleteProductsByNameAndProducer(string name, string producer)
        {
            int countOfRemoved = this.products.RemoveAll(p => p.Name == name && p.Producer == producer);

            if (countOfRemoved > 0)
            {
                return countOfRemoved + ProductsDeleted;
            }

            return NoProductsFound;
        }

        private string DeleteProductsByProducer(string producer)
        {
            int countOfRemoved = this.products.RemoveAll(p => p.Producer == producer);

            if (countOfRemoved > 0)
            {
                return countOfRemoved + ProductsDeleted;
            }

            return NoProductsFound;
        }

        public string ProcessCommand(string command)
        {
            int indexFirstSpace = command.IndexOf(' ');
            string method = command.Substring(0, indexFirstSpace);
            string commandParams = command.Substring(indexFirstSpace + 1);
            string[] tokens = commandParams.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);

            switch (method)
            {
                case "AddProduct":
                    return AddProduct(tokens[0], tokens[1], tokens[2]);
                case "DeleteProducts":
                    if (tokens.Length == 1)
                    {
                        return DeleteProductsByProducer(tokens[0]);
                    }
                    else
                    {
                        return DeleteProductsByNameAndProducer(tokens[0], tokens[1]);
                    }
                case "FindProductsByName":
                    return FindProductsByName(tokens[0]);
                case "FindProductsByPriceRange":
                    return FindProductsByPriceRange(tokens[0], tokens[1]);
                case "FindProductsByProducer":
                    return FindProductsByProducer(tokens[0]);
                default:
                    return IncorrectCommand;
            }
        }
    }
}
