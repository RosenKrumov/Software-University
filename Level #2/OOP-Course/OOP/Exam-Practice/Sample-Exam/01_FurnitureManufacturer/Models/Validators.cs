namespace FurnitureManufacturer.Models
{
    using System;

    public static class Validators
    {
        public static void AssertNotEmpty(string value, string propName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(propName, propName + " must not be empty");
            }
        }

        public static void AssertStringSize(string value, int minSize, string propName)
        {
            if (value.Length < minSize)
            {
                throw new ArgumentException(propName + " length must be greater than 3 characters.");
            }
        }

        public static void AssertMinValue(dynamic value, int minSize, string propName)
        {
            if (value <= minSize)
            {
                throw new ArgumentException(propName, propName + " must be greater than 0.");
            }
        }
    }
}
