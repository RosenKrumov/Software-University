namespace TeamworkProject.Models.Items
{
    using Enums;

    public class Boots : EquippableItem
    {
        private const string BootsName = "Boots";
        private const Items Type = Items.Boots;
        private const decimal BootsPrice = 15;
        private const int BootsArmor = 5;
        private const int BootsAgility = 30;
        private const int BootsStrength = 0;
        private const int BootsHealth = 0;
        private const int BootsIntelligence = 0;

        public Boots()
            : base(BootsName, Type, BootsPrice, BootsStrength, BootsHealth, BootsIntelligence, BootsArmor, BootsAgility)
        {
        }
    }
}