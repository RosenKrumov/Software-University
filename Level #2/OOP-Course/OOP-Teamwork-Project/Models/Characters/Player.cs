namespace TeamworkProject.Models.Characters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Enums;
    using Exceptions;
    using Items;
    using Races;

    [Serializable]
    public class Player : Character
    {
        public Player(string id, Race race)
            : base(id)
        {
            this.Race = race;
            this.Experience = 0;
            this.ExperienceToGetLevel = 40;
            this.Strength += this.Race.StrengthBonus;
            this.Intelligence += this.Race.IntelligenceBonus;
            this.Agility += this.Race.AgillityBonus;
        }
        
        public Dictionary<string, Item> Equipment
        {
            get; 
            set;
        }

        public Location Location
        {
            get; 
            set;
        }

        public int ExperienceToGetLevel
        {
            get; 
            set;
        }
        
        public Race Race 
        {
            get; 
            set; 
        }

        public int Gold
        {
            get; 
            set;
        }

        public int Experience
        {
            get; 
            set;
        }

        public Inventory Inventory
        {
            get; 
            set;
        }

        public int Kills
        {
            get;
            set; 
        }

        public void GetRewards(int goldToTake, int exp, Item item)
        {
            this.Gold += goldToTake;
            this.Inventory.AddItemToInventory(item);
            this.Experience += exp;
        }

        public override void InitBaseStats()
        {
            base.InitBaseStats();
            this.Level = 1;
            this.Gold = 0;
            this.Inventory = new Inventory();
            this.Location = Location.City;
            this.Equipment = new Dictionary<string, Item>();
            this.PhisicalDamage = this.Strength;
            this.Kills = 0;
            this.PhisicalDamage = this.Strength * 2;
            this.CurrentHealth = this.MaxHealth;
            this.MaxMana = this.Intelligence;
            this.CurrentMana = this.MaxMana;
            this.CriticalChance = 2 + (this.Agility / 50);
            this.CriticalDamage = this.PhisicalDamage * this.CriticalChance;
            this.CurrentCriticalChance = this.CriticalDamage;
        }

        public void UpdateStatsUponLevelUp()
        {
            this.MaxHealth += 10;
            this.Level++;
            this.Strength += 1;
            this.Intelligence += 1;
            this.Agility += 1;
            this.Armor += 1;
            this.PointsToSpend += 1;
            this.PhisicalDamage = this.Strength;
            this.MaxMana = this.Intelligence;
            this.CurrentMana = this.MaxMana;
            this.CurrentHealth = this.MaxHealth;
            this.CriticalChance = 2 + (this.Agility / 50);
            this.CriticalDamage = this.PhisicalDamage * this.CriticalChance;
        }

        public void LevelUp()
        {
            int currentExperience = this.Experience;
            while (currentExperience >= this.ExperienceToGetLevel)
            {
                this.UpdateStatsUponLevelUp();
                currentExperience -= this.ExperienceToGetLevel;
                this.ExperienceToGetLevel = 40 * this.Level;
            }

            this.Experience = currentExperience;
        }

        public string ShowStats()
        {
            var sb = new StringBuilder();
            sb.AppendFormat(
                            "Name: {0}\n" +
                            "Level: {1}\n" +
                            "Experience: {2}/{3}\n" +
                            "Strength: {4}\n" +
                            "Critical chance: {14}%\n" +
                            "Health: {10}/{11}\n" +
                            "Intelligence: {5}\n" +
                            "Mana:{12}/{13}\n" +
                            "Agility: {6}\n" +
                            "Armor: {7}\n" +
                            "Gold: {8}\n" +
                            "Items:\n {9}",
                            this.Id, 
                            this.Level, 
                            this.Experience,
                            this.ExperienceToGetLevel, 
                            this.Strength,
                            this.Intelligence, 
                            this.Agility, 
                            this.Armor,
                            this.Gold, 
                            this.Inventory, 
                            this.CurrentHealth, 
                            this.MaxHealth,
                            this.CurrentMana,
                            this.MaxMana,
                            this.CurrentCriticalChance);
            return sb.ToString();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat(
                            "Gold: {0}\nHealth: {1}\nExperience: {2}\nLevel: {3}\n--------------------------\nInventory:\n{4}",
                            this.Gold, 
                            this.CurrentHealth, 
                            this.Experience, 
                            this.Level, 
                            this.Inventory.Items.Last());
            return sb.ToString();
        }

        public void Buy(Item itemToBuy)
        {
            if (this.Gold < itemToBuy.Price)
            {
                throw new InsufficientMoneyException("You do not have enough gold.");
            }

            this.Inventory.AddItemToInventory(itemToBuy);
            this.Gold -= (int)itemToBuy.Price;
        }

        public void Sell(Item itemToSell)
        {
            this.Inventory.Items.Remove(itemToSell);
            this.Gold += (int)itemToSell.Price / 2;
        }

        public void Equip(Item itemToEquip)
        {
            if (this.Equipment.ContainsKey(itemToEquip.Id))
            {
                return;
            }

            this.Equipment.Add(itemToEquip.Id, itemToEquip);
            this.ApplyItemEffect(itemToEquip);
            this.Inventory.Items.Remove(itemToEquip);
        }

        public void Unequip(string itemTypeToUnequip)
        {
            if (this.Equipment.ContainsKey(itemTypeToUnequip))
            {
                this.RemoveItemEffect(this.Equipment[itemTypeToUnequip]);
                this.Inventory.AddItemToInventory(this.Equipment[itemTypeToUnequip]);
                this.Equipment.Remove(itemTypeToUnequip);
            }
            else
            {
                throw new NoSuchItemEquipedException("No item is equiped in slot " + itemTypeToUnequip);
            }
        }

        public void ApplyItemEffect(Item itemToApplyEffect)
        {
            this.Strength += itemToApplyEffect.StrengthBonus;
            this.Agility += itemToApplyEffect.AgilityBonus;
            this.Armor += itemToApplyEffect.ArmorBonus;
            this.MaxHealth += itemToApplyEffect.HealthBonus;
            this.CurrentHealth += itemToApplyEffect.HealthBonus;
            this.Intelligence += itemToApplyEffect.IntelligenceBonus;
            this.PhisicalDamage = this.Strength;
            this.MaxMana = this.Intelligence;
        }

        public void RemoveItemEffect(Item itemToRemoveEffects)
        {
            this.Strength -= itemToRemoveEffects.StrengthBonus;
            this.Agility -= itemToRemoveEffects.AgilityBonus;
            this.Armor -= itemToRemoveEffects.ArmorBonus;
            this.MaxHealth -= itemToRemoveEffects.HealthBonus;
            if (this.CurrentHealth > this.MaxHealth)
            {
                this.CurrentHealth = this.MaxHealth;
            }

            this.Intelligence -= itemToRemoveEffects.IntelligenceBonus;
        }

        public void SubstractMana(int manaToSubstract)
        {
            this.CurrentMana -= manaToSubstract;
        }

        public string EquipmentDetails()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var keyValuePair in this.Equipment)
            {
                sb.AppendFormat("{0}-{1}\n", keyValuePair.Key, keyValuePair.Value.ToString());
            }

            return sb.ToString();
        }
    }
}