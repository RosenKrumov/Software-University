namespace Estates.Data
{
    using Interfaces;

    public class Office : BuildingEstate, IOffice
    {
        public Office(string name, EstateType type, double area, string location, bool isFurnished, int rooms, bool hasElevator) 
            : base(name, type, area, location, isFurnished, rooms, hasElevator)
        {
        }

        public Office(EstateType type)
            : base(type)
        {
        }
    }
}
