using System.Text;

namespace RestaurantManager.Models
{
    using Interfaces;

    public class Dessert : Meal, IDessert
    {
        public Dessert(string name, decimal price, int calories, int quantityPerServing, MetricUnit unit, int timeToPrepare, bool isVegan, bool withSugar)
            : base(name, price, calories, quantityPerServing, unit, timeToPrepare, isVegan)
        {
            this.WithSugar = withSugar;
        }

        public bool WithSugar { get; set; }

        public void ToggleSugar()
        {
            this.WithSugar = !this.WithSugar;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            if (!this.WithSugar)
            {
                result.Append("[NO SUGAR] ");
            }

            result.Append(base.ToString());
            return result.ToString();
        }
    }
}
