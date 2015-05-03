using System.Text;

namespace RestaurantManager.Models
{
    using Interfaces;

    public class Salad : Meal, ISalad
    {
        public Salad(string name, decimal price, int calories, int quantityPerServing, MetricUnit unit, int timeToPrepare, bool isVegan, bool containsPasta)
            : base(name, price, calories, quantityPerServing, unit, timeToPrepare, isVegan)
        {
            this.ContainsPasta = containsPasta;
        }

        public bool ContainsPasta { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(base.ToString())
                .AppendFormat("Contains pasta: {0}", this.ContainsPasta ? "yes" : "no");
            return result.ToString();
        }

    }
}
