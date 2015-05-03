namespace TeamworkProject.Models.Items
{
    using Enums;

    public class Chest : EquippableItem
    {
        private const string ChestName = "Chest";
        private const Items Type = Items.Chest;
        private const decimal ChestPrice = 20;
        private const int ChestArmor = 18;
        private const int ChestHealth = 0;
        private const int ChestStrength = 0;
        private const int ChestAgility = 0;
        private const int ChestIntelligence = 0;

        public Chest()
            : base(ChestName, Type, ChestPrice, ChestStrength, ChestHealth, ChestIntelligence, ChestArmor, ChestAgility)
        {
        }
    }
}