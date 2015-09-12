namespace BidSystem.Data.Interfaces
{
    using Models;

    public interface IBidSystemData
    {
        IRepository<Bid> Bids { get; }
        IRepository<Offer> Offers { get; }
        IRepository<User> Users { get; }
        int SaveChanges();
    }
}
