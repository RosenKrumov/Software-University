namespace TeamworkProject.Models.Characters
{
    using System;
    using Interfaces;
    using Items;

    [Serializable]
    public abstract class Character : GameObject, IAttackable
    {
        private readonly Random random = new Random();

        protected Character(string id)
            : base(id)
        {
            this.InitBaseStats();
        }

        public int CurrentHealth
        {
            get; 
            protected set;
        }

        public int CurrentMana
        {
            get; 
            protected set;
        }

        public int MaxMana
        {
            get; 
            protected set;
        }

        public int Level
        {
            get; 
            set;
        }

        public int Strength
        {
            get; 
            set;
        }

        public int Intelligence
        {
            get; 
            set;
        }

        public int Armor
        {
            get; 
            set;
        }

        public int Agility
        {
            get; 
            set;
        }

        public int PhisicalDamage
        {
            get; 
            set;
        }

        public int PointsToSpend
        {
            get; 
            set;
        }

        public int MaxHealth
        {
            get; 
            protected set;
        }

        public int CriticalChance
        {
            get;
            set;
        }

        public int CriticalDamage
        {
            get;
            set;
        }

        public int CurrentCriticalChance
        {
            get; 
            set;
        }

        public override string ToString()
        {
            return base.ToString() +
                string.Format(
                                "Health: {0}\n" +
                                "Level: {1}\n" +
                                "Strength: {2}\n", 
                                this.CurrentHealth, 
                                this.Level, 
                                this.Strength);
        }

        public void RespondToAttack(int attackDamage)
        {
            this.CurrentHealth -= attackDamage - (this.Armor / 2);
        }

        public int AttackDamage()
        {
            int damage = this.PhisicalDamage;
            int randomNumber = this.random.Next(0, 101);
            if (randomNumber <= this.CurrentCriticalChance)
            {
                Console.WriteLine("CRITICAL");
                damage = this.CriticalDamage;
            }

            return damage;
        }

        public bool CanAttack()
        {
            return this.CurrentHealth > 0;
        }

        public virtual void InitBaseStats()
        {
            this.MaxHealth = 100;
            this.Strength = 5;
            this.Intelligence = 5;
            this.Agility = 5;
            this.Armor = 5;
            this.PointsToSpend = 1;
            this.PhisicalDamage = this.Strength * 2;
            this.CurrentHealth = this.MaxHealth;
            this.MaxMana = this.Intelligence;
            this.CurrentMana = this.MaxMana;
            this.CriticalChance = 2 + (this.Agility / 50);
            this.CriticalDamage = this.PhisicalDamage * (2 + (this.Agility / 50));
            this.CurrentCriticalChance = this.CriticalDamage;
        }
    }
}