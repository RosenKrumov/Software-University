namespace TeamworkProject.Interfaces
{
    public interface IEquippable
    {
        int StrengthBonus
        {
            get; set;
        }

        int HealthBonus
        {
            get; set;
        }

        int IntelligenceBonus
        {
            get; set;
        }

        int ArmorBonus
        {
            get; set;
        }
    }
}