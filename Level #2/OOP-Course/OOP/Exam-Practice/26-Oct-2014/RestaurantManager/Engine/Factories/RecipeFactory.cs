namespace RestaurantManager.Engine.Factories
{
    using System;
    using Interfaces;
    using Interfaces.Engine;
    using Models;

    public class RecipeFactory : IRecipeFactory
    {
        public IDrink CreateDrink(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isCarbonated)
        {
            IDrink drink = new Drink(name, price, calories, quantityPerServing, MetricUnit.Milliliters, timeToPrepare, isCarbonated);
            return drink;
        }

        public ISalad CreateSalad(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool containsPasta)
        {
            ISalad salad = new Salad(name, price, calories, quantityPerServing, MetricUnit.Grams, timeToPrepare, true, containsPasta);
            return salad;
        }
        
        public IMainCourse CreateMainCourse(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan, string type)
        {
            var typeEnum = (MainCourseType)Enum.Parse(typeof (MainCourseType), type);
            IMainCourse mainCourse = new MainCourse(name, price, calories, quantityPerServing, MetricUnit.Grams, timeToPrepare, isVegan, typeEnum);
            return mainCourse;
        }

        public IDessert CreateDessert(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan)
        {
            IDessert dessert = new Dessert(name, price, calories, quantityPerServing, MetricUnit.Grams, timeToPrepare, isVegan, true);
            return dessert;
        }
    }
}
