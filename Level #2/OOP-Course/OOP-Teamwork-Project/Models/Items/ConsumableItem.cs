namespace TeamworkProject.Models.Items
{
    using System;
    using Interfaces;

    public class ConsumableItem : Item, IConsumable
    {
        private int turnsOfEffect;
        
        public ConsumableItem(string name, decimal price, int turnsOfEffect, int healthBonus, int strengthBonus, int agilityBonus, int intelligenceBonus, int armorBonus)
            : base(name, price, healthBonus, strengthBonus, agilityBonus, intelligenceBonus, armorBonus)
        {
            this.TurnsOfEffect = turnsOfEffect;
        }

        public int TurnsOfEffect
        {
            get 
            {
                return this.turnsOfEffect;            
            }

            set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Effect time must be positive.");
                }

                this.turnsOfEffect = value;
            }
        }
    }
}