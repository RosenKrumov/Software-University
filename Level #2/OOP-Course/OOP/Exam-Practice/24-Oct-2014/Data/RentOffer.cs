namespace Estates.Data
{
    using Interfaces;

    public class RentOffer : Offer, IRentOffer
    {
        private decimal pricePerMonth;

        public RentOffer(OfferType type, IEstate estate, decimal pricePerMonth) 
            : base(type, estate)
        {
            this.PricePerMonth = pricePerMonth;
        }

        public RentOffer(OfferType type)
            : base(type)
        {
        }

        public decimal PricePerMonth
        {
            get { return this.pricePerMonth; }
            set
            {
                this.pricePerMonth = value;
                //TODO validation
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Price = {0}", this.PricePerMonth);
        }
    }
}
