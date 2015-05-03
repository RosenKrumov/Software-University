namespace FurnitureManufacturer.Engine.Factories
{
    using System;
    using Interfaces;
    using Interfaces.Engine;
    using Models;

    public class FurnitureFactory : IFurnitureFactory
    {
        private const string Wooden = "wooden";
        private const string Leather = "leather";
        private const string Plastic = "plastic";
        private const string InvalidMaterialName = "Invalid material name: {0}";

        public ITable CreateTable(string model, string materialType, decimal price, decimal height, decimal length, decimal width)
        {
            MaterialType matType = this.GetMaterialType(materialType);
            var table = new Table(model, matType, price, height, length, width);
            return table;
        }

        public IChair CreateChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            MaterialType matType = this.GetMaterialType(materialType);
            var chair = new Chair(model, matType, price, height, numberOfLegs);
            return chair;
        }

        public IAdjustableChair CreateAdjustableChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            MaterialType matType = this.GetMaterialType(materialType);
            var adjustableChair = new AdjustableChair(model, matType, price, height, numberOfLegs);
            return adjustableChair;
        }

        public IConvertibleChair CreateConvertibleChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            MaterialType matType = this.GetMaterialType(materialType);
            var convertibleChair = new ConvertibleChair(model, matType, price, height, numberOfLegs);
            return convertibleChair;
        }

        private MaterialType GetMaterialType(string material)
        {
            switch (material)
            {
                case Wooden:
                    return MaterialType.Wooden;
                case Leather:
                    return MaterialType.Leather;
                case Plastic:
                    return MaterialType.Plastic;
                default:
                    throw new ArgumentException(string.Format(InvalidMaterialName, material));
            }
        }
    }
}
