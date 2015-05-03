namespace TeamworkProject.Models.Items
{
    using Enums;

    public class Gloves : EquippableItem
    {
        private const string GlovesName = "Gloves";
        private const Items Type = Items.Gloves;
        private const decimal GlovesPrice = 18;
        private const int GlovesStrength = 5;
        private const int GlovesHealth = 0;
        private const int GlovesIntelligence = 2;
        private const int GlovesArmor = 10;
        private const int GlovesAgility = 10;

        public Gloves()
            : base(GlovesName, Type, GlovesPrice, GlovesStrength, GlovesHealth, GlovesIntelligence, GlovesArmor, GlovesAgility)
        {
        }
    }
}