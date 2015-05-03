namespace TheSlum.Characters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TheSlum.Interfaces;

    class Warrior : Character, IAttack
    {
        private int attackPoints;

        public int AttackPoints 
        {
            get { return this.attackPoints; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Attack points should be positive.");
                }
                this.attackPoints = value;
            }
        }

        public Warrior(string id, int x, int y, int healthPoints, int defensePoints, Team team, int range, int attackPoints)
            : base(id, x, y, healthPoints, defensePoints, team, range)
        {
            this.AttackPoints = attackPoints;
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            return targetsList.FirstOrDefault(c => (c.IsAlive && this.Team != c.Team));
        }
    }
}
