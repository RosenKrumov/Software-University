namespace CollectionOfProducts
{
    using System.Collections.Generic;

    public interface ICollectionOfProducts
    {
        void AddProduct(Product product);
        bool RemoveProduct(int id);
        IEnumerable<Product> FindProducts(decimal startPrice, decimal endPrice);
        IEnumerable<Product> FindProducts(string title);
        IEnumerable<Product> FindProducts(string title, decimal price);
        IEnumerable<Product> FindProductsByTitleAndPriceRange(string title, decimal startPrice, decimal endPrice);
        IEnumerable<Product> FindProductsBySupplierAndPrice(string supplier, decimal price);
        IEnumerable<Product> FindProducts(string supplier, decimal startPrice, decimal endPrice);
    }
}
