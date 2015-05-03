namespace TeamworkProject.Models.Characters
{
    using System;
    using Races;

    [Serializable]
    public class Fighter : Player
    {
        public readonly int DamageBuffManaCost = 20;
        public readonly int BodyOfSteelBuffManaCost = 20;
        public readonly int HeavySlashManaCost = 30;
        public readonly int BuffTurnsOfEffect = 4;
        private const int BuffModifier = 4;
 
        public Fighter(string id, Race race)
            : base(id, race)
        {
            this.StrengthBonus = 10;
            this.Strength += this.StrengthBonus;
        }

        public int StrengthBonus { get; set; }

        public void ApplyDamageBuff()
        {
            this.SubstractMana(this.DamageBuffManaCost);
            this.PhisicalDamage = this.PhisicalDamage * BuffModifier;
        }

        public void ApplyBodyOfSteelBuff()
        {
            this.SubstractMana(this.BodyOfSteelBuffManaCost);
            this.Armor *= BuffModifier;
        }

        public int HeavySlashDamage()
        {
            this.SubstractMana(this.HeavySlashManaCost);
            return this.PhisicalDamage * 2;
        }

        public void Debuff(string buff)
        {
            if (buff == "DamageBuff")
            {
                this.PhisicalDamage = this.PhisicalDamage / BuffModifier;
            }
            else
            {
                this.Armor = this.Armor / BuffModifier;
            }
        }
    }
}