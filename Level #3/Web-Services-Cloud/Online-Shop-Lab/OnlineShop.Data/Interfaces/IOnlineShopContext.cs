namespace OnlineShop.Data.Interfaces
{
    using System.Data.Entity;
    using Models;

    public interface IOnlineShopContext
    {
        IDbSet<Ad> Ads { get; set; }
        IDbSet<AdType> AdTypes { get; set; }
        IDbSet<Category> Categories { get; set; } 
    }
}
