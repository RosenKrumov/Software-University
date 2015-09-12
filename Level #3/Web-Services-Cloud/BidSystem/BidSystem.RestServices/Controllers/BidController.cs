namespace BidSystem.RestServices.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Data.Data;
    using Data.Interfaces;
    using Microsoft.AspNet.Identity;
    using Models;

    [RoutePrefix("api/bids")]
    public class BidController : BaseApiController
    {
        public BidController()
            : this(new BidSystemData(new BidSystemDbContext()))
        {
            
        }

        public BidController(IBidSystemData data) 
            : base(data)
        {
        }

        [Route("my")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetUserBids()
        {
            var userId = this.User.Identity.GetUserId();

            if (!this.Data.Users.All().Any(u => u.Id == userId))
            {
                return this.Unauthorized();
            }

            var bids = this.Data.Bids.All()
                .Where(b => b.Bidder.Id == userId)
                .OrderByDescending(b => b.Date)
                .Select(BidsViewModel.Create);

            return this.Ok(bids);
        }

        [Route("won")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetUserWonBids()
        {
            var userId = this.User.Identity.GetUserId();

            if (!this.Data.Users.All().Any(u => u.Id == userId))
            {
                return this.Unauthorized();
            }

            var bids = this.Data.Bids.All()
                .Where(
                    b =>
                        b.Offer.Bids.OrderByDescending(ob => ob.BidPrice).FirstOrDefault().BidPrice == b.BidPrice &&
                        DateTime.Now > b.Offer.ExpirationDate)
                .Select(BidsViewModel.Create);

            return this.Ok(bids);
        }
    }
}
