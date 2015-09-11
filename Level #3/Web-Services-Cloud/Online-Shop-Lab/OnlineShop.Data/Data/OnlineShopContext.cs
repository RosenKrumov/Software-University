namespace OnlineShop.Data.Data
{
    using System.Data.Entity;
    using Interfaces;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;
    using Models;

    public class OnlineShopContext : IdentityDbContext<ApplicationUser>, IOnlineShopContext
    {
        public OnlineShopContext()
            : base("name=OnlineShopContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<OnlineShopContext, Configuration>());
        }

        public static OnlineShopContext Create()
        {
            return new OnlineShopContext();
        }

        public virtual IDbSet<Ad> Ads { get; set; }
        public virtual IDbSet<AdType> AdTypes { get; set; }
        public virtual IDbSet<Category> Categories { get; set; } 
    }
}