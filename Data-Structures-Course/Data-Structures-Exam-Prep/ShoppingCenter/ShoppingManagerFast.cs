namespace ShoppingCenter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class ShoppingManagerFast
    {
        private const string ProductAdded = "Product added";
        private const string ProductsDeleted = " products deleted";
        private const string NoProductsFound = "No products found";
        private const string IncorrectCommand = "Incorrect command";

        private readonly MultiDictionary<string, Product> productsByName = 
            new MultiDictionary<string, Product>(true);
        private readonly MultiDictionary<string, Product> productsByProducer = 
            new MultiDictionary<string, Product>(true);
        private readonly MultiDictionary<string, Product> productsByNameAndProducer = 
            new MultiDictionary<string, Product>(true); 
        private readonly OrderedMultiDictionary<decimal, Product> productsByPrice = 
            new OrderedMultiDictionary<decimal, Product>(true);

        private string AddProduct(string name, string price, string producer)
        {
            Product product = new Product()
            {
                Name = name,
                Producer = producer,
                Price = decimal.Parse(price)
            };

            this.productsByName.Add(name, product);
            string nameAndProducerKey = this.CombineNameAndProducerKey(name, producer);
            this.productsByNameAndProducer.Add(nameAndProducerKey, product);
            this.productsByPrice.Add(product.Price, product);
            this.productsByProducer.Add(producer, product);

            return ProductAdded;
        }

        private string CombineNameAndProducerKey(string name, string producer)
        {
            return name + ';' + producer;
        }

        private string FindProductsByName(string name)
        {
            var products = this.productsByName[name];
            return SortAndPrintProducts(products);
        }

        private string SortAndPrintProducts(IEnumerable<Product> products)
        {
            if (products.Any())
            {
                var sortedProducts = new List<Product>(products);
                sortedProducts.Sort();
                var output = new StringBuilder();

                foreach (var sortedProduct in sortedProducts)
                {
                    output.AppendLine(sortedProduct.ToString());
                }

                output.Length -= Environment.NewLine.Length;

                string formattedProducts = output.ToString();
                return formattedProducts;
            }

            return NoProductsFound;
        }

        private string FindProductsByProducer(string producer)
        {
            return SortAndPrintProducts(this.productsByProducer[producer]);
        }

        private string FindProductsByPriceRange(string start, string end)
        {
            var startPrice = decimal.Parse(start);
            var endPrice = decimal.Parse(end);
            return SortAndPrintProducts(this.productsByPrice.Range(startPrice, true, endPrice, true).Values);
        }

        private string DeleteProductsByNameAndProducer(string name, string producer)
        {
            string nameAndProducerKey = this.CombineNameAndProducerKey(name, producer);
            var productsToBeRemoved = this.productsByNameAndProducer[nameAndProducerKey];

            if (productsToBeRemoved.Any())
            {
                int countOfRemoved = productsToBeRemoved.Count;
                foreach (var product in productsToBeRemoved)
                {
                    this.productsByProducer.Remove(product.Producer, product);
                    this.productsByName.Remove(product.Name, product);
                    this.productsByPrice.Remove(product.Price, product);
                }

                this.productsByNameAndProducer.Remove(nameAndProducerKey);
                return countOfRemoved + ProductsDeleted;
            }

            return NoProductsFound;
        }

        private string DeleteProductsByProducer(string producer)
        {
            var productsToBeRemoved = this.productsByProducer[producer];

            if (productsToBeRemoved.Any())
            {
                int countOfRemoved = productsToBeRemoved.Count;
                foreach (var product in productsToBeRemoved)
                {
                    this.productsByName.Remove(product.Name, product);
                    this.productsByPrice.Remove(product.Price, product);
                    string nameAndProducer = this.CombineNameAndProducerKey(product.Name, producer);
                    this.productsByNameAndProducer.Remove(nameAndProducer, product);
                }

                this.productsByProducer.Remove(producer);
                return countOfRemoved + ProductsDeleted;
            }

            return NoProductsFound;
        }

        public string ProcessCommand(string command)
        {
            int indexOfFirstSpace = command.IndexOf(' ');
            string method = command.Substring(0, indexOfFirstSpace);
            string parameterValues = command.Substring(indexOfFirstSpace + 1);
            string[] parameters =
                parameterValues.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            switch (method)
            {
                case "AddProduct":
                    return AddProduct(parameters[0], parameters[1], parameters[2]);
                case "DeleteProducts":
                    if (parameters.Length == 1)
                    {
                        return DeleteProductsByProducer(parameters[0]);
                    }
                    else
                    {
                        return DeleteProductsByNameAndProducer(parameters[0], parameters[1]);
                    }
                case "FindProductsByName":
                    return FindProductsByName(parameters[0]);
                case "FindProductsByPriceRange":
                    return FindProductsByPriceRange(parameters[0], parameters[1]);
                case "FindProductsByProducer":
                    return FindProductsByProducer(parameters[0]);
                default:
                    return IncorrectCommand;
            }
        }
    }
}
