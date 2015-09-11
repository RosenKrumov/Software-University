namespace OnlineShop.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data.Interfaces;
    using Models;
    using Moq;

    public class MockContainer
    {
        public Mock<IRepository<Ad>> AdRepositoryMock { get; set; }

        public Mock<IRepository<Category>> CategoryRepositoryMock { get; set; }

        public Mock<IRepository<AdType>> AdTypeRepositoryMock { get; set; }

        public Mock<IRepository<ApplicationUser>> UserRepositoryMock { get; set; }

        public void PrepareMocks()
        {
            this.SetupFakeCategories();
            this.SetupFakeUsers();
            this.SetupFakeAds();
            this.SetupFakeAdTypes();
        }

        private void SetupFakeAdTypes()
        {
            var fakeAdTypes = new List<AdType>()
            {
                new AdType(){Name = "Gold", Index = 300, Id = 4},
                new AdType(){Name = "Silver", Index = 150, Id = 5}
            };

            this.AdTypeRepositoryMock = new Mock<IRepository<AdType>>();
            this.AdTypeRepositoryMock.Setup(r => r.All())
                .Returns(fakeAdTypes.AsQueryable());

            this.AdTypeRepositoryMock.Setup(r => r.Find(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    var type = fakeAdTypes.FirstOrDefault(t => t.Id == id);
                    return type;
                });
        }

        private void SetupFakeUsers()
        {
            var fakeUsers = new List<ApplicationUser>()
            {
                new ApplicationUser(){UserName = "zidarq", Id = "111"},
                new ApplicationUser(){UserName = "hlebarq", Id = "222"}
            };

            this.UserRepositoryMock = new Mock<IRepository<ApplicationUser>>();
            this.UserRepositoryMock.Setup(r => r.All())
                .Returns(fakeUsers.AsQueryable());

            this.UserRepositoryMock.Setup(r => r.Find(It.IsAny<string>()))
                .Returns((string id) =>
                {
                    var user = fakeUsers.FirstOrDefault(u => u.Id == id);
                    return user;
                });
        }

        private void SetupFakeCategories()
        {
            var fakeCategories = new List<Category>()
            {
                new Category(){Id = 1, Name = "Cars"},
                new Category(){Id = 2, Name = "Girls"},
                new Category(){Id = 3, Name = "Laptops"}
            };

            this.CategoryRepositoryMock = new Mock<IRepository<Category>>();
            this.CategoryRepositoryMock.Setup(r => r.All())
                .Returns(fakeCategories.AsQueryable());

            this.CategoryRepositoryMock.Setup(r => r.Find(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    var category = fakeCategories.FirstOrDefault(c => c.Id == id);
                    return category;
                });
        }

        private void SetupFakeAds()
        {
            var adTypes = new List<AdType>()
            {
                new AdType() {Name = "Normal", Index = 100},
                new AdType() {Name = "Premium", Index = 200}
            };

            var fakeAds = new List<Ad>()
            {
                new Ad()
                {
                    Id = 5,
                    Name = "Audi A6",
                    Type = adTypes[0],
                    PostedOn = DateTime.Now.AddDays(-6),
                    Owner = new ApplicationUser(){UserName = "gosho", Id = "123"},
                    Price = 400
                },
                new Ad()
                {
                    Id = 6,
                    Name = "Audi A5",
                    Type = adTypes[1],
                    PostedOn = DateTime.Now,
                    Owner = new ApplicationUser(){UserName = "darvarq", Id = "234"}
                }
            };

            this.AdRepositoryMock = new Mock<IRepository<Ad>>();
            this.AdRepositoryMock.Setup(r => r.All())
                .Returns(fakeAds.AsQueryable());

            this.AdRepositoryMock.Setup(r => r.Find(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    var ad = fakeAds.FirstOrDefault(a => a.Id == id);
                    return ad;
                });
        }
    }
}
