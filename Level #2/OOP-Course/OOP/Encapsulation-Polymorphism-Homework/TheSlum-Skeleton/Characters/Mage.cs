namespace TheSlum.Characters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TheSlum.Interfaces;

    class Mage : Character, IAttack
    {
        private int attackPoints;

        public int AttackPoints 
        {
            get { return this.AttackPoints; }
            
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Attack points should be positive.");
                }
                this.attackPoints = value;
            }
        }

        public Mage(string id, int x, int y, int healthPoints, int defensePoints, Team team, int range, int attackPoints)
            : base(id, x, y, healthPoints, defensePoints, team, range)
        {
            this.AttackPoints = attackPoints;
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            return targetsList.LastOrDefault(c => (c.IsAlive && this.Team != c.Team));
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
