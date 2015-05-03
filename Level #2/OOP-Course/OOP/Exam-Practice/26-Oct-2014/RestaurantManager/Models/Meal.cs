using System.Text;

namespace RestaurantManager.Models
{
    using Interfaces;

    public class Meal : Recipe, IMeal
    {
        public Meal(string name, decimal price, int calories, int quantityPerServing, MetricUnit unit, int timeToPrepare, bool isVegan)
            : base(name, price, calories, quantityPerServing, unit, timeToPrepare)
        {
            this.IsVegan = isVegan;
        }

        public bool IsVegan { get; set; }

        public void ToggleVegan()
        {
            this.IsVegan = !this.IsVegan;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            if (this.IsVegan)
            {
                result.Append("[VEGAN] ");
            }

            result.Append(base.ToString());
            return result.ToString();
        }
    }
}
