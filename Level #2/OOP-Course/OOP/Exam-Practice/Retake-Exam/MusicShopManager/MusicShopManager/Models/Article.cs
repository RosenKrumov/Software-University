using System.Text;
using MusicShopManager.Interfaces;

namespace MusicShop.Models
{
    public class Article : IArticle
    {
        public Article(string make, string model, decimal price)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendFormat("= {0} {1} =\nPrice: ${2:F2}\n", 
                this.Make, this.Model, this.Price);
            return result.ToString();
        }
    }
}
