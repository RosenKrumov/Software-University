namespace BidSystem.RestServices.Models
{
    using System;
    using System.Linq.Expressions;
    using Data.Models;

    public class BidsViewModel
    {
        public int Id { get; set; }
        public int OfferId { get; set; }
        public DateTime DateCreated { get; set; }
        public string Bidder { get; set; }
        public decimal OfferedPrice { get; set; }
        public string Comment { get; set; }

        public static Expression<Func<Bid, BidsViewModel>> Create
        {
            get
            {
                return b => new BidsViewModel()
                {
                    Id = b.Id,
                    OfferId = b.Offer.Id,
                    DateCreated = b.Date,
                    Bidder = b.Bidder.UserName,
                    OfferedPrice = b.BidPrice,
                    Comment = b.Comment
                };
            }
        }
    }
}