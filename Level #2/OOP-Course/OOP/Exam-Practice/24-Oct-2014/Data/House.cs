namespace Estates.Data
{
    using Interfaces;

    public class House : Estate, IHouse
    {
        private int floors;

        public House(string name, EstateType type, double area, string location, bool isFurnished, int floors) 
            : base(name, type, area, location, isFurnished)
        {
            this.Floors = floors;
        }

        public House(EstateType type)
            : base(type)
        {
        }

        public int Floors
        {
            get { return this.floors; }
            set
            {
                this.floors = value;
                //TODO validation
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Floors: {0}", this.Floors);
        }
    }
}
