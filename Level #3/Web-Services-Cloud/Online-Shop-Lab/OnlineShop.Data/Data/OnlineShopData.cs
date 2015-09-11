namespace OnlineShop.Data.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using Interfaces;
    using Models;

    public class OnlineShopData : IOnlineShopData
    {
        private readonly DbContext context;
        private readonly IDictionary<Type, object> repositories;

        public OnlineShopData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Ad> Ads
        {
            get { return this.GetRepository<Ad>(); }
        }

        public IRepository<AdType> AdTypes
        {
            get { return this.GetRepository<AdType>(); }
        }

        public IRepository<Category> Categories
        {
            get { return this.GetRepository<Category>(); }
        }

        public IRepository<ApplicationUser> Users
        {
            get { return this.GetRepository<ApplicationUser>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public int SaveChangesAsync()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof (T);

            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof (Repository<T>);
                var repository = Activator.CreateInstance(typeOfRepository, this.context);
                this.repositories.Add(type, repository);
            }

            return (IRepository<T>) this.repositories[type];
        }
    }
}
