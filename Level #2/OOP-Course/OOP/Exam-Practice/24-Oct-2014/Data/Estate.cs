namespace Estates.Data
{
    using System.Text;
    using Interfaces;

    public class Estate : IEstate
    {
        private string name;
        private double area;
        private string location;

        public Estate(string name, EstateType type, double area, string location, bool isFurnished)
            : this(type)
        {
            this.Name = name;
            this.Area = area;
            this.Location = location;
            this.IsFurnished = isFurnished;
        }

        public Estate(EstateType type)
        {
            this.Type = type;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                //TODO validation
            }
        }

        public EstateType Type { get; set; }

        public double Area
        {
            get { return this.area; }
            set
            {
                this.area = value;
                //TODO validation
            }
        }

        public string Location
        {
            get { return this.location; }
            set
            {
                this.location = value;
                //TODO validation
            }
        }

        public bool IsFurnished { get; set; }

        public override string ToString()
        {
            var furnitured = this.IsFurnished ? "Yes" : "No";
            var sb = new StringBuilder();
            sb.AppendFormat(
                "{4}: Name = {0}, " +
                "Area = {1}, " +
                "Location = {2}, " +
                "Furnitured = {3}, ",
                this.Name,
                this.Area,
                this.Location,
                furnitured,
                this.Type);
            return sb.ToString();
        }
    }
}
