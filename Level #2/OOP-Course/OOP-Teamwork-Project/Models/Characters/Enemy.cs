namespace TeamworkProject.Models.Characters
{
    using System;

    public abstract class Enemy : NonPlayerCharacter
    {
        private int goldOnDeath;
        private int experienceOnDeath;

        protected Enemy(string id, int goldOnDeath, int experienceOnDeath, int level)
            : base(id)
        {
            this.ExperienceOnDeath = experienceOnDeath;
            this.GoldOnDeath = goldOnDeath;
            this.Level = level;
        }

        protected Enemy(string id, int level)
            : base(id)
        {
           this.Level = level;
        }

        public int ExperienceOnDeath
        {
            get
            {
                return this.experienceOnDeath;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Experience on death must be positive.");
                }
            
                this.experienceOnDeath = value;
            }
        }

        public int GoldOnDeath
        {
            get
            {
                return this.goldOnDeath;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Gold on death must be positive.");
                }
            
                this.goldOnDeath = value;
            }
        }
    }
}