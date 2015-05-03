namespace TeamworkProject.Models.Items
{
    using System;
    using Interfaces;

    [Serializable]
    public abstract class Item : GameObject, ISellable
    {
        private decimal price;
        private int healthBonus;
        private int strengthBonus;
        private int agilityBonus;
        private int intelligenceBonus;
        private int armorBonus;

        protected Item(string id, decimal price, int healthBonus, int strengthBonus, int agilityBonus, int intelligenceBonus, int armorBonus)
            : base(id)
        {
            this.Price = price;
            this.StrengthBonus = strengthBonus;
            this.AgilityBonus = agilityBonus;
            this.IntelligenceBonus = intelligenceBonus;
            this.ArmorBonus = armorBonus;
        }

        public decimal Price
        {
            get 
            { 
                return this.price; 
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be negative.");
                }

                this.price = value;
            }
        }

        public int HealthBonus
        {
            get
            {
                return this.healthBonus;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Restored health must be positive.");
                }

                this.healthBonus = value;
            }
        }

        public int StrengthBonus
        {
            get
            {
                return this.strengthBonus;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Temp strength bonus must be positive.");
                }

                this.strengthBonus = value;
            }
        }

        public int AgilityBonus
        {
            get
            {
                return this.agilityBonus;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Temp agility bonus must be positive.");
                }

                this.agilityBonus = value;
            }
        }

        public int IntelligenceBonus
        {
            get
            {
                return this.intelligenceBonus;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Intelligence bonus must be positive.");
                }

                this.intelligenceBonus = value;
            }
        }

        public int ArmorBonus
        {
            get
            {
                return this.armorBonus;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Armor bonus must be positive.");
                }

                this.armorBonus = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
                                "name: {0}, " +
                                "price: {1}, " +
                                "health: {2}, " +
                                "strength: {3}, " +
                                "agility: {4}, " +
                                "intelligence: {5}, " +
                                "armor: {6}",
                                this.Id, 
                                this.Price, 
                                this.HealthBonus, 
                                this.StrengthBonus, 
                                this.AgilityBonus, 
                                this.IntelligenceBonus, 
                                this.armorBonus);
        }
    }
}