namespace Estates.Data
{
    using Interfaces;

    public class Apartment : BuildingEstate, IApartment
    {
        public Apartment(string name, EstateType type, double area, string location, bool isFurnished, int rooms, bool hasElevator) 
            : base(name, type, area, location, isFurnished, rooms, hasElevator)
        {
        }

        public Apartment(EstateType type)
            : base(type)
        {
        }
    }
}
