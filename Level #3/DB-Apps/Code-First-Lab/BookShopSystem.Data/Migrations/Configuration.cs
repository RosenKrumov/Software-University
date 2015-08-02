using System;
using System.Globalization;
using System.IO;
using System.Linq;
using BookShopSystem.Models;

namespace BookShopSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<BookShopSystem.Data.BookShopContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "BookShopSystem.Data.BookShopContext";
        }

        protected override void Seed(BookShopContext context)
        {
            
        }
    }
}
