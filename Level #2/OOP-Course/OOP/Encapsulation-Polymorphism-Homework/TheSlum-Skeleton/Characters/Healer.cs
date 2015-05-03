namespace TheSlum.Characters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TheSlum.Interfaces;

    /*
     I looked at another person's code in order to manage to make fix to the engine. 
     It is not all my personal code, but I hope it works fine.
     */

    class Healer : Character, IHeal
    {
        private int healingPoints;

        public int HealingPoints
        { 
            get { return this.healingPoints; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Healing points should be positive.");
                }
                this.healingPoints = value;
            }
        }

        public Healer(string id, int x, int y, int healthPoints, int defensePoints, Team team, int range, int healingPoints)
            : base(id, x, y, healthPoints, defensePoints, team, range)
        {
            this.HealingPoints = healingPoints;
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            return targetsList.OrderBy(c => c.HealthPoints).First(c => !c.Equals(this));
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
        }
    }
}
