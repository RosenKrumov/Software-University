namespace TeamworkProject.Models.Races
{
    using System;

    [Serializable]
    public class HumanRace : Race
    {
        private const int HumanIntelligenceBonus = 10;
        private const int HumanStrengthBonus = 0;
        private const int HumanAgillityBonus = 0;
        
        public HumanRace()
            : base(HumanIntelligenceBonus, HumanStrengthBonus, HumanAgillityBonus)
        {
        }
    }
}