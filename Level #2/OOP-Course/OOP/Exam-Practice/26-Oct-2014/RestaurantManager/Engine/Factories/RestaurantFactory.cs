namespace RestaurantManager.Engine.Factories
{
    using Interfaces.Engine;
    using Interfaces;
    using Models;


    public class RestaurantFactory : IRestaurantFactory
    {
        public IRestaurant CreateRestaurant(string name, string location)
        {
            IRestaurant restaurant = new Restaurant(name, location);
            return restaurant;
        }
    }
}
