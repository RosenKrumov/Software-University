namespace CollectionOfProducts
{
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class CollectionOfProducts : ICollectionOfProducts
    {
        private readonly IDictionary<int, Product> productsById = 
            new Dictionary<int, Product>(); 

        private readonly OrderedDictionary<decimal, SortedSet<Product>> productsByPrice =
            new OrderedDictionary<decimal, SortedSet<Product>>();

        private readonly IDictionary<string, SortedSet<Product>> productsByTitle = 
            new Dictionary<string, SortedSet<Product>>(); 

        private readonly IDictionary<string, SortedSet<Product>> productsByTitlePrice =
            new Dictionary<string, SortedSet<Product>>();

        private readonly IDictionary<string, SortedSet<Product>> productsBySupplierPrice =
            new Dictionary<string, SortedSet<Product>>();

        private readonly IDictionary<string, OrderedDictionary<decimal, SortedSet<Product>>> productsByTitlePriceRange =
            new Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>>();

        private readonly IDictionary<string, OrderedDictionary<decimal, SortedSet<Product>>> productsBySupplierPriceRange = 
            new Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>>();

        public void AddProduct(Product product)
        {
            //I am not sure if we have to remove the previous product, I think it just overwrites it.
            if (this.productsById.ContainsKey(product.Id))
            {
                this.RemoveProduct(product.Id);
            }

            this.productsById[product.Id] = product; 

            this.productsByPrice.AppendValueToKey(product.Price, product);
            this.productsByTitle.AppendValueToKey(product.Title, product);

            var titleAndPrice = this.CombineNameAndPrice(product.Title, product.Price);
            this.productsByTitlePrice.AppendValueToKey(titleAndPrice, product);

            var supplierAndPrice = this.CombineNameAndPrice(product.Supplier, product.Price);
            this.productsBySupplierPrice.AppendValueToKey(supplierAndPrice, product);

            this.productsByTitlePriceRange.EnsureKeyExists(product.Title);
            this.productsByTitlePriceRange[product.Title].AppendValueToKey(product.Price, product);

            this.productsBySupplierPriceRange.EnsureKeyExists(product.Supplier);
            this.productsBySupplierPriceRange[product.Supplier].AppendValueToKey(product.Price, product);
        }

        public bool RemoveProduct(int id)
        {
            if (!this.productsById.ContainsKey(id))
            {
                return false;
            }

            var product = this.productsById[id];

            this.productsById.Remove(id);
            this.productsByPrice[product.Price].Remove(product);
            this.productsByTitle[product.Title].Remove(product);

            var titleAndPrice = this.CombineNameAndPrice(product.Title, product.Price);
            var supplierAndPrice = this.CombineNameAndPrice(product.Supplier, product.Price);

            this.productsByTitlePrice[titleAndPrice].Remove(product);
            this.productsBySupplierPrice[supplierAndPrice].Remove(product);

            this.productsBySupplierPriceRange[product.Supplier][product.Price].Remove(product);
            this.productsByTitlePriceRange[product.Title][product.Price].Remove(product);

            return true;
        }

        public IEnumerable<Product> FindProducts(decimal startPrice, decimal endPrice)
        {
            var productsInPriceRange = this.productsByPrice.Range(startPrice, true, endPrice, true);

            foreach (var pair in productsInPriceRange)
            {
                foreach (var product in pair.Value)
                {
                    yield return product;
                }
            }
        }

        public IEnumerable<Product> FindProducts(string title)
        {
            return this.productsByTitle.GetValuesForKey(title);
        }

        public IEnumerable<Product> FindProducts(string title, decimal price)
        {
            var titleAndPrice = this.CombineNameAndPrice(title, price);
            return this.productsByTitlePrice.GetValuesForKey(titleAndPrice);
        }

        public IEnumerable<Product> FindProductsByTitleAndPriceRange(string title, decimal startPrice, decimal endPrice)
        {
            if (!this.productsByTitlePriceRange.ContainsKey(title))
            {
                yield break;
            }

            var productsInRange = this.productsByTitlePriceRange[title].Range(startPrice, true, endPrice, true);

            foreach (var pair in productsInRange)
            {
                foreach (var product in pair.Value)
                {
                    yield return product;
                }
            }
        }

        public IEnumerable<Product> FindProductsBySupplierAndPrice(string supplier, decimal price)
        {
            var supplierAndPrice = this.CombineNameAndPrice(supplier, price);
            return this.productsBySupplierPrice.GetValuesForKey(supplierAndPrice);
        }

        public IEnumerable<Product> FindProducts(string supplier, decimal startPrice, decimal endPrice)
        {
            if (!this.productsBySupplierPriceRange.ContainsKey(supplier))
            {
                yield break;
            }

            var productsInRange = this.productsBySupplierPriceRange[supplier].Range(startPrice, true, endPrice, true);

            foreach (var pair in productsInRange)
            {
                foreach (var product in pair.Value)
                {
                    yield return product;
                }
            }
        }

        private string CombineNameAndPrice(string name, decimal price)
        {
            const string separator = "|!|";
            return name + separator + price;
        }
    }
}
