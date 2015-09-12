namespace BidSystem.RestServices.Models
{
    using System;
    using System.Linq.Expressions;
    using Data.Models;

    public class OfferBidsViewModel
    {
        public int Id { get; set; }
        public int OfferId { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal OfferedPrice { get; set; }
        public string Comment { get; set; }

        public static Expression<Func<Bid, OfferBidsViewModel>> Create
        {
            get
            {
                return b => new OfferBidsViewModel
                {
                    Id = b.Id,
                    OfferId = b.Offer.Id,
                    DateCreated = b.Date,
                    OfferedPrice = b.BidPrice,
                    Comment = b.Comment
                };
            }
        }
    }
}