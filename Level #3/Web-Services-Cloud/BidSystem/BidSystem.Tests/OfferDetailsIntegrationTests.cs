namespace BidSystem.Tests
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Data.Data;
    using Data.Models;
    using EntityFramework.Extensions;
    using Microsoft.Owin.Testing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Owin;
    using RestServices;

    [TestClass]
    public class OfferDetailsIntegrationTests
    {
        private static TestServer httpTestServer;
        private static HttpClient httpClient;

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            httpTestServer = TestServer.Create(appBuilder =>
            {
                var config = new HttpConfiguration();
                WebApiConfig.Register(config);

                var startup = new Startup();
                startup.Configuration(appBuilder);

                appBuilder.UseWebApi(config);
            });

            httpClient = httpTestServer.HttpClient;
            SeedDatabase();
        }

        [TestInitialize]
        private static void SeedDatabase()
        {
            var context = new BidSystemDbContext();

            var offer = new Offer()
            {
                Id = 1,
                Title = "Motika",
                PublishDate = DateTime.Now,
                InitialPrice = 300,
                ExpirationDate = DateTime.Now.AddDays(10)
            };

            context.Offers.Add(offer);

            context.SaveChanges();
        }

        [TestMethod]
        public void Getting_Offer_Valid_Id_Should_Return_200Ok()
        {
            var response = httpClient.GetAsync("/api/offers/details/1").Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void Getting_Offer_Invalid_Id_Should_Return_404NotFound()
        {
            var response = httpClient.GetAsync("api/offers/details/2").Result;

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestCleanup]
        private static void CleanDatabase()
        {
            var context = new BidSystemDbContext();
            context.Database.Delete();
        }

        [AssemblyCleanup]
        public static void AssemblyCleanUp()
        {
            if (httpTestServer != null)
            {
                httpTestServer.Dispose();
                CleanDatabase();
            }
        }
    }
}
