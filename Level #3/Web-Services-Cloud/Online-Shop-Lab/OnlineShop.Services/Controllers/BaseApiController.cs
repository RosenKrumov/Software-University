namespace OnlineShop.Services.Controllers
{
    using System.Web.Http;
    using Data.Interfaces;
    using Infrastructure;

    public class BaseApiController : ApiController
    {
        public BaseApiController(IOnlineShopData data, IUserIdProvider provider)
        {
            this.Data = data;
            this.UserIdProvider = provider;
        }

        protected IOnlineShopData Data { get; set; }

        protected IUserIdProvider UserIdProvider { get; set; }
    }
}
