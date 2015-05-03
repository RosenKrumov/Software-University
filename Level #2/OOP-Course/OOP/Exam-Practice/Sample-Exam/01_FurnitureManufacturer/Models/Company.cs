namespace FurnitureManufacturer.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using FurnitureManufacturer.Interfaces;

    public class Company : ICompany
    {
        private List<IFurniture> furnitures = new List<IFurniture>();

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
        }

        public string Name { get; private set; }

        public string RegistrationNumber { get; private set; }

        public ICollection<IFurniture> Furnitures
        {
            get { return this.furnitures; }
        }

        public void Add(IFurniture furniture)
        {
            this.furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            this.furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            return this.furnitures
                .FirstOrDefault(t => t.Model.ToLowerInvariant() == model.ToLowerInvariant());
        }

        public string Catalog()
        {
            StringBuilder catalog = new StringBuilder();

            string catalogHeader = string.Format("{0} - {1} - {2} {3}",
                this.Name,
                this.RegistrationNumber,
                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                this.Furnitures.Count != 1 ? "furnitures" : "furniture");
            catalog.Append(catalogHeader);

            var sortedFurnitures = this.Furnitures
                .OrderBy(t => t.Price)
                .ThenBy(t => t.Model);

            foreach (var furniture in sortedFurnitures)
            {
                catalog.AppendLine();
                string furnitureStr = furniture.ToString();
                catalog.Append(furnitureStr);
            }

            return catalog.ToString();
        }
    }
}