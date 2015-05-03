using System;
using System.Text;

namespace RestaurantManager.Models
{
    using Interfaces;

    public class Recipe : IRecipe
    {
        public Recipe(string name, decimal price, int calories, int quantityPerServing, MetricUnit unit,
            int timeToPrepare)
        {
            this.Name = name;
            this.Price = price;
            this.Calories = calories;
            this.QuantityPerServing = quantityPerServing;
            this.Unit = unit;
            this.TimeToPrepare = timeToPrepare;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Calories { get; set; }

        public int QuantityPerServing { get; set; }

        public MetricUnit Unit { get; set; }

        public int TimeToPrepare { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendFormat("==  {0} == ${1:F2}", this.Name, this.Price).AppendLine()
                .AppendFormat("Per serving: {0} {1}, {2} kcal", this.QuantityPerServing, this.GetUnitString(), this.Calories).AppendLine()
                .AppendFormat("Ready in {0} minutes", this.TimeToPrepare);
            return result.ToString();
        }

        private string GetUnitString()
        {
            switch (this.Unit)
            {
                case MetricUnit.Grams:
                    return "g";
                case MetricUnit.Milliliters:
                    return "ml";
                default:
                    throw new InvalidOperationException("Invalid type of unit selected.");
            }
        }
    }
}
