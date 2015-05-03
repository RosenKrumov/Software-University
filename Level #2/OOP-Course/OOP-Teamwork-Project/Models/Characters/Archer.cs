namespace TeamworkProject.Models.Characters
{
    using System;
    using Races;

    [Serializable]
    public class Archer : Player
    {
        public readonly int MultiShotManaCost = 30;
        public readonly int HeadshotManaCost = 20;
        public readonly int MarkTargetManaCost = 20;

        public readonly int ArcherBuffTurnsOfEffect = 4;

        public Archer(string id, Race race)
            : base(id, race)
        {
            this.AgilityBonus = 10;
            this.Agility += this.AgilityBonus;
        }

        public int AgilityBonus { get; set; }

        public int MultiShotAttackTimes()
        {
            this.SubstractMana(this.MultiShotManaCost);
            return 3 + (this.Agility / 25);
        }

        public int HeadshotDamage()
        {
            this.SubstractMana(this.HeadshotManaCost);
            return this.CriticalDamage;
        }

        public void MarkTargetBuff()
        {
            this.SubstractMana(this.MarkTargetManaCost);
            this.CurrentCriticalChance += 50;
        }

        public void Debuff()
        {
            this.CriticalChance -= 50;
        }
    }
}