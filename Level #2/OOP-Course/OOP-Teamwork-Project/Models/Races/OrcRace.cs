namespace TeamworkProject.Models.Races
{
    using System;

    [Serializable]
    public class OrcRace : Race
    {
        private const int OrcIntelligenceBonus = 0;
        private const int OrcStrengthBonus = 10;
        private const int OrcAgillityBonus = 0;

        public OrcRace()
            : base(OrcIntelligenceBonus, OrcStrengthBonus, OrcAgillityBonus)
        {
        }
    }
}