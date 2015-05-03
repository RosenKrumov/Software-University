namespace TeamworkProject.Models.Characters
{
    using System;
    using Races;

    [Serializable]
    public class Mage : Player
    {
        public readonly int MageFrostShieldManaCost = 25;
        public readonly int MageFlameStrikeManaCost = 25;
        public readonly int MageHealManaCost = 25;
        public readonly int MageFrostShieldTurnsOfEffect = 4;
        private const int MageFrostShieldModifier = 2;
        private const int HealModifier = 3;

        public Mage(string id, Race race)
            : base(id, race)
        {
            this.IntelligenceBonus = 2;
            this.Intelligence += this.IntelligenceBonus;
        }

        public int IntelligenceBonus { get; set; }

        public void FrostShieldEffects()
        {
            this.SubstractMana(this.MageFrostShieldManaCost);
            this.Armor = (this.Armor * MageFrostShieldModifier) + this.Intelligence;
        }

        public int GetFlameStrikeDamage()
        {
            this.SubstractMana(this.MageFlameStrikeManaCost);
            return this.Intelligence * 3;
        }

        public void HealEffects()
        {
            this.SubstractMana(this.MageHealManaCost);
            if (this.CurrentHealth >= this.MaxHealth - (this.MaxHealth / HealModifier))
            {
                this.CurrentHealth = this.MaxHealth;
            }
            else
            {
                this.CurrentHealth += this.MaxHealth / HealModifier;
            }
        }

        public void Debuff()
        {
            this.Armor /= MageFrostShieldModifier;
        }
    }
}