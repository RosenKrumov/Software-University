namespace TeamworkProject.Models.Items
{
    using Enums;

    public class Helmet : EquippableItem
    {
        private const string HelmetName = "Helmet";
        private const Items Type = Items.Helmet;
        private const decimal HelmetPrice = 50;
        private const int HelmetStrength = 5;
        private const int HelmetHealth = 0;
        private const int HelmetIntelligence = 0;
        private const int HelmetArmor = 10;
        private const int HelmetAgility = 0;

        public Helmet() 
            : base(HelmetName, Type, HelmetPrice, HelmetStrength, HelmetHealth, HelmetIntelligence, HelmetArmor, HelmetAgility)
        {
        }
    }
}