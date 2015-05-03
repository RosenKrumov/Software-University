namespace TeamworkProject.Models.Items
{
    using Enums;

    public class Weapon : EquippableItem
    {
        private const string WeaponName = "Weapon";
        private const Items Type = Items.Weapon;
        private const decimal WeaponPrice = 30;
        private const int WeaponStrength = 25;
        private const int WeaponHealth = 0;
        private const int WeaponArmor = 0;
        private const int WeaponIntelligence = 0;
        private const int WeaponAgility = 0;

        public Weapon() 
            : base(WeaponName, Type, WeaponPrice, WeaponStrength, WeaponHealth, WeaponArmor, WeaponIntelligence, WeaponAgility)
        {
        }
    }
}