using System.Linq;
using BookShopSystem.Data;

namespace BookShopSystem.Services.Controllers
{
    using System.Web.Http;

    public class UserController : ApiController
    {
        private readonly BookShopSystemContext data;

        public UserController(BookShopSystemContext context)
        {
            this.data = context;
        }

        public UserController()
            :this(new BookShopSystemContext())
        {
        }

        [Authorize]
        [Route("api/users/{username}/purchases")]
        [HttpGet]
        public IHttpActionResult GetUserPurchases(string username)
        {
            var purchases = this.data.Purchases
                .Where(p => p.User.UserName.ToLower() == username.Trim().ToLower())
                .OrderBy(p => p.PurchaseDate)
                .Select(p => new
                {
                    p.Book.Title,
                    p.Price,
                    p.PurchaseDate,
                    p.IsRecalled
                });
            
            var output = new
            {
                Username = username,
                Purchases = purchases
            };

            return this.Ok(output);
        }
    }
}
