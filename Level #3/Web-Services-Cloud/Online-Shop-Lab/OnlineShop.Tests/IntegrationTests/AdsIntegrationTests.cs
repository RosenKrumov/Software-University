namespace OnlineShop.Tests.IntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Data.Data;
    using Data.Interfaces;
    using EntityFramework.Extensions;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Owin.Testing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Owin;
    using Services;

    [TestClass]
    public class AdsIntegrationTests
    {
        private static TestServer httpTestServer;
        private static HttpClient httpClient;
        private const string TestUserUsername = "zidarq";
        private const string TestUserPassword = "stenichkata";
        private string accessToken;

        private string AccessToken
        {
            get
            {
                if (this.accessToken == null)
                {
                    var loginResponse = this.Login();
                    if (!loginResponse.IsSuccessStatusCode)
                    {
                        Assert.Fail("Unable to login: " + loginResponse.ReasonPhrase);
                    }

                    var loginData = loginResponse.Content.ReadAsAsync<LoginDTO>().Result;
                    this.accessToken = loginData.Access_Token;
                }

                return this.accessToken;
            }
        }

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
            var context = new OnlineShopContext();
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new ApplicationUserManager(userStore);

            var user = new ApplicationUser()
            {
                UserName = TestUserUsername,
                Email = "zidarq@stenichkata.bg"
            };

            var result = userManager.CreateAsync(user, TestUserPassword).Result;

            if (!result.Succeeded)
            {
                Assert.Fail(string.Join(Environment.NewLine, result.Errors));
            }

            SeedCategories(context);
            SeedAdTypes(context);

            context.SaveChanges();
        }

        private static void SeedAdTypes(IOnlineShopContext context)
        {
            var types = new List<AdType>()
            {
                new AdType(){Name = "Gold", Index = 300, Id = 4},
                new AdType(){Name = "Silver", Index = 150, Id = 5},
                new AdType(){Name = "Bronze", Index = 100, Id = 6}
            };

            types.ForEach(t => context.AdTypes.Add(t));
        }

        private static void SeedCategories(IOnlineShopContext context)
        {
            var categories = new List<Category>()
            {
                new Category(){Id = 1, Name = "Cars"},
                new Category(){Id = 2, Name = "Girls"},
                new Category(){Id = 3, Name = "Laptops"},
                new Category(){Id = 4, Name = "Houses"}
            };

            categories.ForEach(c => context.Categories.Add(c));
        }

        [TestCleanup]
        private static void CleanDatabase()
        {
            var context = new OnlineShopContext();
            context.Ads.Delete();
            context.AdTypes.Delete();
            context.Categories.Delete();
            context.Users.Delete();
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

        private HttpResponseMessage Login()
        {
            var loginData = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", TestUserUsername),
                new KeyValuePair<string, string>("password", TestUserPassword),
                new KeyValuePair<string, string>("grant_type", "password") 
            });

            var response = httpClient.PostAsync("/Token", loginData).Result;
            return response;
        }

        [TestMethod]
        public void Login_Should_Return_200Ok_And_Token()
        {
            var loginResponse = this.Login();

            Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);

            var loginData = loginResponse.Content
                .ReadAsAsync<LoginDTO>().Result;

            Assert.IsNotNull(loginData.Access_Token);
        }

        private HttpResponseMessage PostNewAd(FormUrlEncodedContent content)
        {
            if (!httpClient.DefaultRequestHeaders.Contains("Authorization"))
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + this.AccessToken);
            }

            return httpClient.PostAsync("/api/ads", content).Result;
        }

        [TestMethod]
        public void Posting_Ad_With_Invalid_AdType_Should_Return_400BadRequest()
        {
            var context = new OnlineShopContext();
            var category = context.Categories.First();

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name", "Opel Astra"),
                new KeyValuePair<string, string>("description", "..."),
                new KeyValuePair<string, string>("price", "2000"),
                new KeyValuePair<string, string>("typeId", "-1"),
                new KeyValuePair<string, string>("categories[0]", category.Id.ToString()), 
            });

            var response = this.PostNewAd(content);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Posting_Ad_Without_Categories_Should_Return_400BadRequest()
        {
            //Category[] categories = new Category[0];
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name", "Opel Astra"),
                new KeyValuePair<string, string>("description", "..."),
                new KeyValuePair<string, string>("price", "2000"),
                new KeyValuePair<string, string>("typeId", "-1"),
                new KeyValuePair<string, string>("categories", ""), 
            });

            var response = this.PostNewAd(content);
            var message = response.Content.ReadAsStringAsync();
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Posting_Ad_With_More_Than_Three_Categories_Should_Return_400BadRequest()
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name", "Opel Astra"),
                new KeyValuePair<string, string>("description", "..."),
                new KeyValuePair<string, string>("price", "2000"),
                new KeyValuePair<string, string>("typeId", "-1"),
                new KeyValuePair<string, int[]>("categories", new int[4]{1, 2, 3, 4}), 
            });

            var response = this.PostNewAd(content);
            var message = response.Content.ReadAsStringAsync();
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
