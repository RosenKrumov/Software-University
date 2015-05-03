namespace ConsoleApplication1.Models.Races
{
    using System;
    using TeamworkProject.Models.Races;

    [Serializable]
    public class ElfRace : Race
    {
        private const int ElfAgillityBonus = 10;
        private const int ElfStrengthBonus = 0;
        private const int ElfIntelligenceBonus = 0;

        public ElfRace()
            : base(ElfIntelligenceBonus, ElfStrengthBonus, ElfAgillityBonus)
        {
        }
    }
}
