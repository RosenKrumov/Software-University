namespace TeamworkProject.Core
{
    using System;
    using System.Collections.Generic;
    using Enums;
    using Models.Characters;
    using Models.Items;
    using Models.Races;

    public static class UnitsFactory
    {
        public static IEnumerable<Enemy> GenerateEnemies(int playerLevel, int enemiesCount, bool shouldGenerateBoss)
        {
            var values = Enum.GetValues(typeof(MobNames));
            IList<Enemy> enemies = new List<Enemy>();
            var random = new Random();
            var mobLevel = 1;
            if (shouldGenerateBoss)
            {
                Enemy boss = new Boss("Boss", playerLevel + 5);
                enemies.Add(boss);
            }

            for (var i = 0; i < enemiesCount; i++)
            {
                if (playerLevel > 1)
                {
                    mobLevel = random.Next(playerLevel - 1, playerLevel + 2);
                }

                var mobGoldOnDeath = random.Next(5 * playerLevel, (20 * playerLevel) + 1);
                var mobExperienceOnDeath = (20 * mobLevel) - (10 * playerLevel);
                var randomMobName = (MobNames)values.GetValue(random.Next(values.Length));
                var randomMobNameString = randomMobName.ToString();
                Enemy enemy = new Mob(randomMobNameString, mobGoldOnDeath, mobExperienceOnDeath, mobLevel);
                enemies.Add(enemy);
            }

            return enemies;
        }

        public static Player GeneratePlayer(Race race, string role, string name)
        {
            switch (role.ToLower())
            {
                case "fighter":
                    return new Fighter(name, race);
                case "archer":
                    return new Archer(name, race);
                case "mage":
                    return new Mage(name, race);
                default:
                    return null;
            }
        }

        public static Item GenerateItem(int level)
        {
            var random = new Random();
            var price = random.Next(level * 100, level * 120);
            var strBonus = random.Next(0, level + 5);
            var intellBonus = random.Next(0, level + 5);
            var agillityBonus = random.Next(0, level + 5);
            var values = Enum.GetValues(typeof(Items));
            var randomItem = (Items)values.GetValue(random.Next(values.Length));
            var randomItemstring = randomItem.ToString();
            var healthBonus = random.Next(0, 10 * level);
            var armorBonus = random.Next(0, 10 * level);
            return new EquippableItem(
                randomItemstring, randomItem, price, strBonus, healthBonus, intellBonus, armorBonus, agillityBonus);
        }
    }
}