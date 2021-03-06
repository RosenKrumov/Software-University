using Microsoft.AspNet.Identity.EntityFramework;

namespace BookShopSystem.Data
{
    using System.Data.Entity;
    using Models;
    using Migrations;

    public class BookShopSystemContext : IdentityDbContext<ApplicationUser>
    {
        public BookShopSystemContext()
            : base("name=BookShopContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookShopSystemContext, Configuration>());
        }

        public static BookShopSystemContext Create()
        {
            return new BookShopSystemContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(b => b.RelatedBooks)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("BookId");
                    m.MapRightKey("RelatedBookId");
                    m.ToTable("BookRelatedBooks");
                });
            base.OnModelCreating(modelBuilder);
        }

        public IDbSet<Author> Authors { get; set; }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Purchase> Purchases { get; set; } 
    }
}