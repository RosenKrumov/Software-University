namespace TeamworkProject.Models.Characters
{
    public class Mob : Enemy
    {
        public Mob(string id, int goldOnDeath, int experienceOnDeath, int level) 
            : base(id, goldOnDeath, experienceOnDeath, level)
        {
           this.InitBaseStats();
        }

        public override sealed void InitBaseStats()
        {
            base.InitBaseStats();
            this.CurrentHealth = 40 + (15 * this.Level);
            this.PhisicalDamage = 5 * this.Level;
            this.Agility = 3 * this.Level;
            this.Armor = 3 * this.Level;
        }
    }
}