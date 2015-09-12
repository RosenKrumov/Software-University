namespace BidSystem.Data.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;
    using Models;

    public class BidSystemDbContext : IdentityDbContext<User>
    {
        public BidSystemDbContext()
            : base("BidSystem")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BidSystemDbContext, BidSystemDbMigrationConfiguration>());
        }
        
        public static BidSystemDbContext Create()
        {
            return new BidSystemDbContext();
        }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<Bid> Bids { get; set; }
    }
}
