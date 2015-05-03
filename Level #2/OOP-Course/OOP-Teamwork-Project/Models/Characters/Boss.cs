namespace TeamworkProject.Models.Characters
{
    public class Boss : Enemy
    {
        public Boss(string id, int level)
            : base(id, level)
        {
            this.InitBaseStats();
        }

        public override sealed void InitBaseStats()
        {
            base.InitBaseStats();
            this.GoldOnDeath = 100 * this.Level;
            this.ExperienceOnDeath = 100 * this.Level;
            this.CurrentHealth = 50 * this.Level;
            this.PhisicalDamage = 5 * this.Level;
            this.Agility = 5 * this.Level;
            this.Armor = 5 * this.Level;
        }
    }
}
