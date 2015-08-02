using ProductsShop.Migrations;
using ProductsShop.Models;

namespace ProductsShop
{
    using System.Data.Entity;

    public class ProductsShopEntities : DbContext
    {
        public ProductsShopEntities()
            : base("name=ProductsShopEntities")
        {
            var migrationStrategy = new MigrateDatabaseToLatestVersion<ProductsShopEntities, Configuration>();
            Database.SetInitializer(migrationStrategy);
        }

        public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<Product> Products { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasMany(u => u.Friends)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("FriendId");
                    m.ToTable("UsersFriends");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}