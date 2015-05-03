using System;

namespace Estates.Data
{
    using Engine;
    using Interfaces;

    public class EstateFactory
    {
        public static IEstateEngine CreateEstateEngine()
        {
            return new NewEstateEngine();
        }

        public static IEstate CreateEstate(EstateType type)
        {
            IEstate estate;

            switch (type)
            {
                case EstateType.Apartment:
                    estate = new Apartment(type);
                    break;
                case EstateType.Garage:
                    estate = new Garage(type);
                    break;
                case EstateType.House:
                    estate = new House(type);
                    break;
                case EstateType.Office:
                    estate = new Office(type);
                    break;
                default:
                    throw new ArgumentException("Estate type does not exist");
            }
            
            return estate;
        }

        public static IOffer CreateOffer(OfferType type)
        {
            IOffer offer;

            switch (type)
            {
                case OfferType.Rent:
                    offer = new RentOffer(type);
                    break;
                case OfferType.Sale:
                    offer = new SaleOffer(type);
                    break;
                default:
                    throw new ArgumentException("Offer type does not exist.");
            }

            return offer;
        }
    }
}
