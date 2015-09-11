namespace OnlineShop.Services.Controllers
{
    using Data.Interfaces;
    using Infrastructure;

    public class CategoriesController : BaseApiController
    {
        public CategoriesController(IOnlineShopData data, IUserIdProvider provider) 
            : base(data, provider)
        {
        }
    }
}
