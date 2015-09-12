namespace BidSystem.RestServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Data.Models;

    public class GetOfferViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Seller { get; set; }
        public DateTime DatePublished { get; set; }
        public decimal InitialPrice { get; set; }
        public DateTime ExpirationDateTime { get; set; }
        public bool IsExpired { get; set; }
        public string BidWinner { get; set; }
        public IEnumerable<OfferBidsViewModel> Bids { get; set; }

        public static Expression<Func<Offer, GetOfferViewModel>> Create
        {
            get
            {
                return o => new GetOfferViewModel()
                {
                    Id = o.Id,
                    Title = o.Title,
                    Description = o.Description,
                    Seller = o.Seller.UserName,
                    DatePublished = o.PublishDate,
                    InitialPrice = o.InitialPrice,
                    ExpirationDateTime = o.ExpirationDate,
                    IsExpired = DateTime.Now > o.ExpirationDate,
                    BidWinner = DateTime.Now > o.ExpirationDate && o.Bids.Count > 0
                        ? null
                        : o.Bids.OrderByDescending(b => b.BidPrice).Select(b => b.Bidder.UserName).FirstOrDefault(),
                    Bids = o.Bids.OrderByDescending(b => b.Date)
                        .Select(b => new OfferBidsViewModel()
                        {
                            Id = b.Id,
                            OfferId = b.Offer.Id,
                            DateCreated = b.Date,
                            OfferedPrice = b.BidPrice,
                            Comment = b.Comment
                        })
                };
            }
        } 
    }
}