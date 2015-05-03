using System;
using System.Text;

namespace RestaurantManager.Models
{
    using Interfaces;

    public class MainCourse : Meal, IMainCourse
    {
        private MainCourseType type;

        public MainCourse(string name, decimal price, int calories, int quantityPerServing, MetricUnit unit, int timeToPrepare, bool isVegan, MainCourseType type)
            : base(name, price, calories, quantityPerServing, unit, timeToPrepare, isVegan)
        {
            this.Type = type;
        }

        public MainCourseType Type { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(base.ToString())
                .AppendFormat("Type: {0}", this.Type.ToString());
            return result.ToString();
        }
    }
}
