using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using System.Xml;

namespace ProductsShop.Migrations
{
    using ProductsShop.Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductsShopEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ProductsShopEntities context)
        {
            var random = new Random();
            var serializer = new JavaScriptSerializer();

            if (!context.Users.Any())
            {
                var document = new XmlDocument();
                document.Load("../../users.xml");
                var users = document.DocumentElement;

                foreach (XmlNode user in users)
                {
                    string firstName = null;
                    if (user.Attributes["first-name"] != null)
                    {
                        firstName = user.Attributes["first-name"].Value;
                    }

                    string lastName = user.Attributes["last-name"].Value;
                    int? age = null;

                    if (user.Attributes["age"] != null)
                    {
                        age = Convert.ToInt32(user.Attributes["age"].Value);
                    }

                    context.Users.Add(new User
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age
                    });
                }
            }

            context.SaveChanges();

            if (!context.Products.Any())
            {
                var file = File.ReadAllText("../../products.json");
                var products = (List<Product>)serializer.Deserialize(file, typeof(List<Product>));
                var userIds = context.Users.Select(u => u.Id);

                var index = 1;
                foreach (var product in products)
                {
                    int? randomBuyerIndex = null;
                    if (index % 2 == 0)
                    {
                        product.BuyerId = userIds.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                    }

                    product.SellerId = userIds.OrderBy(x => Guid.NewGuid()).FirstOrDefault(); ;

                    context.Products.Add(product);
                    index++;
                }
            }

            context.SaveChanges();

            if (!context.Categories.Any())
            {
                var categories = new List<Category>();
                var file = File.ReadAllText("../../categories.json");
                categories = (List<Category>) serializer.Deserialize(file, typeof (List<Category>));

                foreach (var product in context.Products)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        var randomCategoryIndex = random.Next(0, categories.Count);
                        product.Categories.Add(categories[randomCategoryIndex]);
                    }
                }
            }

            context.SaveChanges();
        }
    }
}
