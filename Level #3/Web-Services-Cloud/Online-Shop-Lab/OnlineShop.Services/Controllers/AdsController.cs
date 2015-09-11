namespace OnlineShop.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Microsoft.AspNet.Identity;
    using Data.Interfaces;
    using Infrastructure;
    using OnlineShop.Models;
    using Models;

    [Authorize]
    public class AdsController : BaseApiController
    {
        public AdsController(IOnlineShopData data, IUserIdProvider provider)
            :base(data, provider)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetAllOpenAds()
        {
            var ads = this.Data.Ads.All()
                .Where(a => a.Status == AdStatus.Open)
                .OrderByDescending(a => a.Type.Id)
                .ThenByDescending(a => a.PostedOn)
                .Select(AdViewModel.Create);

            return this.Ok(ads);
        }

        [HttpPost]
        public IHttpActionResult CreateAd([FromBody]CreateAdBindingModel model)
        {
            var userId = this.UserIdProvider.GetUserId();

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var ad = new Ad()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                PostedOn = DateTime.Now,
                OwnerId = userId
            };

            if (!model.Categories.Any() || model.Categories.Count() > 3)
            {
                return this.BadRequest("Categories count must be between 1 and 3");
            }

            foreach (var categoryId in model.Categories)
            {
                var categoryToAdd = this.Data.Categories.All().FirstOrDefault(c => c.Id == categoryId);
                
                if (categoryToAdd == null)
                {
                    return this.BadRequest(string.Format("Category with id {0} does not exist", categoryId));
                }

                ad.Categories.Add(categoryToAdd);
            }

            var typeToAdd = this.Data.AdTypes.All().FirstOrDefault(t => t.Id == model.TypeId);

            if (typeToAdd == null)
            {
                return this.BadRequest(string.Format("AdType with id {0} does not exist", model.TypeId));
            }

            ad.TypeId = model.TypeId;
            this.Data.Ads.Add(ad);
            this.Data.SaveChanges();

            var result = this.Data.Ads.All()
                .Where(a => a.Id == ad.Id)
                .Select(AdViewModel.Create)
                .FirstOrDefault();

            return this.Ok(result);
        }

        [HttpPut]
        [Authorize]
        [Route("api/ads/{id}/close")]
        public IHttpActionResult CloseAd(int id)
        {
            var ad = this.Data.Ads.All().FirstOrDefault(a => a.Id == id);
            if (ad == null)
            {
                return this.BadRequest("Such ad does not exist");
            }

            var userId = this.UserIdProvider.GetUserId();
            if (ad.OwnerId != userId)
            {
                return this.BadRequest("You must be the owner of the ad in order to close it");
            }

            ad.ClosedOn = DateTime.Now;
            ad.Status = AdStatus.Closed;
            this.Data.SaveChanges();
            return this.Ok("Ad closed successfully");
        }
    }
}
