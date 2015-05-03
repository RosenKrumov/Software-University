namespace Estates.Data
{
    using Interfaces;

    public class SaleOffer : Offer, ISaleOffer
    {
        private decimal price;

        public SaleOffer(OfferType type, IEstate estate, decimal price) 
            : base(type, estate)
        {
            this.Price = price;
        }

        public SaleOffer(OfferType type)
            : base(type)
        {
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                this.price = value;
                //TODO validation
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Price = {0}", this.Price);
        }
    }
}
