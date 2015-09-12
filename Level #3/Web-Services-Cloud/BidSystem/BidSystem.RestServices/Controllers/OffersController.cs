namespace BidSystem.RestServices.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Data.Data;
    using Data.Interfaces;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Models;

    [RoutePrefix("api/offers")]
    public class OffersController : BaseApiController
    {
        public OffersController()
            : this(new BidSystemData(new BidSystemDbContext()))
        {
        }

        public OffersController(IBidSystemData data) 
            : base(data)
        {
        }

        [Route("all")]
        [HttpGet]
        public IHttpActionResult GetAllOffers()
        {
            var offers = this.Data.Offers.All()
                .OrderByDescending(o => o.PublishDate)
                .Select(GetOffersViewModel.Create);

            return this.Ok(offers);
        }

        [Route("active")]
        [HttpGet]
        public IHttpActionResult GetAllActiveOffers()
        {
            var offers = this.Data.Offers.All()
                .Where(o => o.ExpirationDate > DateTime.Now)
                .OrderBy(o => o.ExpirationDate)
                .Select(GetOffersViewModel.Create);

            return this.Ok(offers);
        }

        [Route("expired")]
        [HttpGet]
        public IHttpActionResult GetAllExpiredOffers()
        {
            var offers = this.Data.Offers.All()
                .Where(o => o.ExpirationDate < DateTime.Now)
                .OrderBy(o => o.ExpirationDate)
                .Select(GetOffersViewModel.Create);

            return this.Ok(offers);
        }

        [Route("details/{id}")]
        [HttpGet]
        public IHttpActionResult GetOfferById(int id)
        {
            var offer = this.Data.Offers.All()
                .Select(GetOfferViewModel.Create)
                .FirstOrDefault(o => o.Id == id);

            if (offer == null)
            {
                return this.NotFound();
            }

            return this.Ok(offer);
        }

        [Route("my")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetUserOffers()
        {
            var userId = this.User.Identity.GetUserId();

            if (!this.Data.Users.All().Any(u => u.Id == userId))
            {
                return this.Unauthorized();
            }

            var offers = this.Data.Offers.All()
                .Where(o => o.Seller.Id == userId)
                .OrderBy(o => o.PublishDate)
                .Select(GetOffersViewModel.Create);

            return this.Ok(offers);
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult CreateOffer(CreateOfferBindingModel model)
        {
            var userId = this.User.Identity.GetUserId();
            var user = this.Data.Users.Find(userId);

            if (!this.Data.Users.All().Any(u => u.Id == userId))
            {
                return this.Unauthorized();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var offer = new Offer()
            {
                Title = model.Title,
                Description = string.IsNullOrEmpty(model.Description) ? null : model.Description,
                InitialPrice = model.InitialPrice,
                ExpirationDate = model.ExpirationDate,
                Seller = user,
                PublishDate = DateTime.Now
            };

            this.Data.Offers.Add(offer);
            this.Data.SaveChanges();

            return this.CreatedAtRoute(
                "CustomApi",
                new {action = "details", id = offer.Id},
                new {id = offer.Id, seller = user.UserName, message = "Offer created"});
        }

        [Route("{id}/bid")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult AddBidForOffer(int id, BidBindingModel model)
        {
            var userId = this.User.Identity.GetUserId();
            var user = this.Data.Users.Find(userId);
            var offer = this.Data.Offers.All()
                .Where(o => o.Id == id)
                .Select(o => new
                {
                    o.InitialPrice,
                    o.ExpirationDate,
                    Bids = o.Bids.Select(b => b.BidPrice)
                })
                .FirstOrDefault();

            if (!this.Data.Users.All().Any(u => u.Id == userId))
            {
                return this.Unauthorized();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (offer == null)
            {
                return this.NotFound();
            }

            if (DateTime.Now > offer.ExpirationDate)
            {
                return this.BadRequest("Offer has expired");
            }

            var minBidPrice = offer.InitialPrice;
            if (offer.Bids.Any())
            {
                minBidPrice = offer.Bids.Max();
            }

            if (model.BidPrice <= minBidPrice)
            {
                return this.BadRequest("Your bid should be > " + minBidPrice);
            }

            var bid = new Bid()
            {
                BidPrice = model.BidPrice,
                Comment = string.IsNullOrEmpty(model.Comment) ? null : model.Comment,
                Bidder = user,
                Date = DateTime.Now,
                OfferId = id
            };

            this.Data.Bids.Add(bid);
            this.Data.SaveChanges();

            return this.Ok(new {bid.Id, Bidder = user.UserName, Message = "Bid created."});
        }
    }
}
