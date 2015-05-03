namespace TeamworkProject.Models.Races
{
    using System;

    [Serializable]
    public class Race
    {
        public Race(int intelligenceBonus, int strengthBonus, int agillityBonus)
        {
            this.IntelligenceBonus = intelligenceBonus;
            this.StrengthBonus = strengthBonus;
            this.AgillityBonus = agillityBonus;
        }

        public int AgillityBonus { get; set; }

        public int IntelligenceBonus { get; set; }

        public int StrengthBonus { get; set; }
    }
}