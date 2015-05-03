namespace TeamworkProject.Models.Items
{
    using System.Collections.Generic;
    using Interfaces;

    public class Shop : GameObject, IShop
    {
        public Shop() 
            : base("ItemShop")
        {
            this.ItemsOnShop = this.GenerateItems();
        }

        public IEnumerable<Item> ItemsOnShop { get; private set; }

        private IEnumerable<Item> GenerateItems()
        {
            var items = new List<Item>()
            {
                new HealthPotion(),
                new Helmet(),
                new Boots(),
                new Chest(), 
                new Gloves(),
                new Leggings(),
                new Weapon(),
                new Shield()
            };
            return items;
        }
    }
}