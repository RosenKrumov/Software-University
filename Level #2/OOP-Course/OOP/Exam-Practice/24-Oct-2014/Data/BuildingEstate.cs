namespace Estates.Data
{
    using Interfaces;

    public class BuildingEstate : Estate, IBuildingEstate
    {
        private int rooms;

        public BuildingEstate(string name, EstateType type, double area, string location, bool isFurnished, int rooms, bool hasElevator) 
            : base(name, type, area, location, isFurnished)
        {
            this.Rooms = rooms;
            this.HasElevator = hasElevator;
        }

        public BuildingEstate(EstateType type)
            : base(type)
        {
        }

        public int Rooms
        {
            get { return this.rooms; }
            set
            {
                this.rooms = value;
                //TODO validation
            }
        }

        public bool HasElevator { get; set; }

        public override string ToString()
        {
            var elevator = HasElevator ? "Yes" : "No";
            return base.ToString() + string.Format("Rooms: {0}, Elevator: {1}", this.Rooms, elevator);
        }
    }
}
