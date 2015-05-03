namespace TeamworkProject.Interfaces
{
    using System.Collections.Generic;
    using Models.Items;

    public interface IShop
    {
        IEnumerable<Item> ItemsOnShop { get; }
    }
}