namespace QueryAndExportData
{
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;
    using System.Xml.Linq;
    using ProductsShop;

    public class QueryAndExportData
    {
        static void Main()
        {
            var context = new ProductsShopEntities();
            
            //Problem 3.1
            var products = context.Products
                .Where(p => (p.Price >= 500 && p.Price <= 1000) && p.BuyerId == null)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    SellerName = p.Seller.FirstName + " " + p.Seller.LastName
                });

            var serializer = new JavaScriptSerializer();
            var productsJson = serializer.Serialize(products);
            File.WriteAllText("../../products-in-range.json", productsJson);

            //Problem 3.2
            var users = context.Users
                .Where(u => u.SoldProducts.Count > 0)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    SoldProducts = u.SoldProducts.Select(p => new
                    {
                        p.Name,
                        p.Price,
                        p.Buyer.FirstName,
                        p.Buyer.LastName
                    })
                });

            var usersJson = serializer.Serialize(users);
            File.WriteAllText("../../users-sold-products.json", usersJson);

            //Problem 3.3
            var categories = context.Categories
                .OrderBy(c => c.Products.Count)
                .Select(c => new
                {
                    c.Name,
                    c.Products.Count,
                    AveragePrice = c.Products.Average(p => p.Price),
                    TotalRevenue = c.Products.Sum(p => p.Price)
                });

            var categoriesJson = serializer.Serialize(categories);
            File.WriteAllText("../../categories-by-products.json", categoriesJson);

            //Problem 3.4
            var usersWithProduct = context.Users
                .Where(u => u.SoldProducts.Count > 0)
                .OrderByDescending(u => u.SoldProducts.Count)
                .ThenBy(u => u.LastName)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    Products = u.SoldProducts.Select(p => new
                    {
                        p.Name,
                        p.Price
                    })
                });

            var xmlUsers = new XElement("users",
                new XAttribute("count", usersWithProduct.Count()));

            foreach (var user in usersWithProduct)
            {
                var firstNameAttribute = user.FirstName != null ? new XAttribute("first-name", user.FirstName) : null;
                var ageAttribute = user.Age != null ? new XAttribute("age", user.Age) : null;
                var xmlUser = 
                (
                    new XElement
                    (
                        "user",
                        firstNameAttribute,
                        new XAttribute("last-name", user.LastName),
                        ageAttribute
                    )
                );

                var soldProducts = 
                    new XElement
                    (
                        "sold-products", 
                        new XAttribute
                        (
                            "count", user.Products.Count()
                        )
                    );

                foreach (var product in user.Products)
                {
                    soldProducts.Add
                    (
                        new XElement
                        (
                            "product", 
                            new XAttribute("name", product.Name),
                            new XAttribute("price", product.Price)
                        )
                    );
                }
                xmlUser.Add(soldProducts);
                xmlUsers.Add(xmlUser);
            }

            var document = new XDocument();
            document.Add(xmlUsers);
            document.Save("../../users-and-products.xml");
        }
    }
}
