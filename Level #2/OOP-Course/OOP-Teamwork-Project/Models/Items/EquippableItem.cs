namespace TeamworkProject.Models.Items
{
    using System;
    using Enums;
    using Interfaces;

    [Serializable]
    public class EquippableItem : Item, IEquippable
    {
        public EquippableItem(string name, Items itemType, decimal price, int strengthBonus, int healthBonus, int intelligenceBonus, int armorBonus, int agilityBonus)
            : base(name, price, healthBonus, strengthBonus, agilityBonus, intelligenceBonus, armorBonus)
        {
            this.ItemType = itemType;
            this.StrengthBonus = strengthBonus;
            this.ArmorBonus = armorBonus;
            this.HealthBonus = healthBonus;
            this.IntelligenceBonus = intelligenceBonus;
            this.AgilityBonus = agilityBonus;
        }

        public Items ItemType { get; set; }
    }
}