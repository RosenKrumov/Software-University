namespace TeamworkProject.Models.Items
{
    using Enums;

    public class Shield : EquippableItem
    {
        private const string ShieldName = "Shield";
        private const Items Type = Items.Shield;
        private const decimal ShieldPrice = 25;
        private const int ShieldStrength = 5;
        private const int ShieldHealth = 0;
        private const int ShieldIntelligence = 0;
        private const int ShieldArmor = 15;
        private const int ShieldAgility = 0;

        public Shield()
            : base(ShieldName, Type, ShieldPrice, ShieldStrength, ShieldHealth, ShieldIntelligence, ShieldArmor, ShieldAgility)
        {
        }
    }
}