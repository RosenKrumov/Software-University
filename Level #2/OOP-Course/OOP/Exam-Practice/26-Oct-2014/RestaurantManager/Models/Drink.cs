using System.Text;

namespace RestaurantManager.Models
{
    using Interfaces;

    public class Drink : Recipe, IDrink
    {
        public Drink(string name, decimal price, int calories, int quantityPerServing, MetricUnit unit, int timeToPrepare, bool isCarbonated)
            : base(name, price, calories, quantityPerServing, unit, timeToPrepare)
        {
            this.IsCarbonated = isCarbonated;
        }

        public bool IsCarbonated { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(base.ToString())
                .AppendFormat("Carbonated: {0}", this.IsCarbonated ? "yes" : "no");
            return result.ToString();
        }
    }
}
