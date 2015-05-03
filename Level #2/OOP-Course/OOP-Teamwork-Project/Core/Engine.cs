namespace TeamworkProject.Core
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using ConsoleApplication1.Core;
    using Enums;
    using Exceptions;
    using Interfaces;
    using Models.Characters;
    using Models.Items;

    public class Engine
    {
        private const int EnemiesMaxCount = 10;
        private readonly Dictionary<string, int> playerBuffs = new Dictionary<string, int>();
        private bool isRunning;
        private Player player;
        private List<Enemy> enemies;
        private IShop shop;
        private Dictionary<string, string> playerInfo = new Dictionary<string, string>();

        public void Run()
        {
            this.GetPlayer();
            this.isRunning = true;
            this.enemies = new List<Enemy>();
            this.shop = new Shop();

            while (this.isRunning)
            {
                this.RemoveDeadEnemies();
                var shouldHaveBoss = this.player.Kills % 2 == 0 && this.player.Kills != 0 && !this.enemies.Any(n => n is Boss);
                this.enemies.AddRange(UnitsFactory.GenerateEnemies(this.player.Level, EnemiesMaxCount - this.enemies.Count, shouldHaveBoss));
                this.player.Location = Location.City;

                Console.WriteLine("Welcome to the city!\nChoose a command: (Attack, MoveToShop, Stats, Inventory, Equipment, Save, Load, Exit)");

                var command = Console.ReadLine();
                var commandArgs = InputReader.ExtractArgs(command);
                this.ExecuteCommand(commandArgs);
                this.CheckForLevelUpdate();
            }
        }

        private void GetPlayer()
        {
            var userInput = GameStateManipulator.InteractWithConsoleForPlayerLoad();

            if (userInput == "no")
            {
                this.InitPlayer();
                return;
            }

            try
            {
                GameStateManipulator.PrintSavedGames();
                var playerName = GameStateManipulator.GetPlayerNameForLoad();
                this.player = LoadFileManipulator.Lfoad(playerName);
                Console.WriteLine(this.player != null ? this.player.ShowStats() : "Error loading player");
            }
            catch (Exception e)
            {
                if (e is FileNotFoundException ||
                    e is DirectoryNotFoundException ||
                    e is SerializationException ||
                    e is ArgumentNullException ||
                    e is NullReferenceException)
                {
                    Console.Error.WriteLine(e.Message);
                    this.InitPlayer();
                }
            }
        }

        private void CheckForLevelUpdate()
        {
            if (this.player.Experience < this.player.ExperienceToGetLevel)
            {
                return;
            }

            this.player.LevelUp();
            Console.WriteLine("Level up!");
        }

        private void InitPlayer()
        {
            this.playerInfo = InputReader.ReadInputForPlayer();
            var race = InputReader.ParseRaceFromString(this.playerInfo["race"]);
            this.player = UnitsFactory.GeneratePlayer(race, this.playerInfo["role"], this.playerInfo["name"]);
        }

        #region Attack Executor

        private bool CheckTargetInput(string target)
        {
            var enemyNames = new List<string>();
            this.enemies.ForEach(enemy => enemyNames.Add(enemy.Id.ToLower()));
            if (enemyNames.Contains(target.ToLower()))
            {
                return true;
            }

            Console.WriteLine("Enemy does not exist!");
            return false;
        }

        private void AttackTarget(string target)
        {
            var victim = this.enemies.First(enemy => string.Equals(enemy.Id, target, StringComparison.CurrentCultureIgnoreCase));
            this.FightWithEnemyScreen(victim);
        }

        private void FightWithEnemyScreen(Enemy victim)
        {
            while (true)
            {
                if (this.player.CanAttack())
                {
                    Console.WriteLine("choose attack type: (normal or magic)");
                    this.ManipulateBuffs();
                    var attackType = Console.ReadLine();
                    this.SwitchAttackType(victim, attackType);
                }
                else if (this.player.CurrentHealth <= 0)
                {
                    Console.WriteLine("you died");
                    break;
                }

                if (victim.CanAttack())
                {
                    Console.WriteLine("enemy attacks");
                    this.player.RespondToAttack(victim.AttackDamage());
                }
                else
                {
                    Console.WriteLine("the enemy was killed");
                    var randomItem = UnitsFactory.GenerateItem(victim.Level);
                    this.player.GetRewards(victim.GoldOnDeath, victim.ExperienceOnDeath, randomItem);
                    Console.WriteLine("Your stats after the battle: ");
                    Console.WriteLine(this.player);
                    this.player.Kills += 1;
                    break;
                }
            }
        }

        private void SwitchAttackType(Enemy victim, string attackType)
        {
            switch (attackType)
            {
                case "normal":
                    Console.WriteLine("player attacks");
                    victim.RespondToAttack(this.player.AttackDamage());
                    break;
                case "magic":
                    this.MagicAttack(victim);
                    break;
                default:
                    Console.WriteLine("Invalid attack type");
                    break;
            }
        }

        private void ManipulateBuffs()
        {
            var playerBuffKeys = new List<string>(this.playerBuffs.Keys);
            foreach (var buffName in playerBuffKeys)
            {
                var newBuffValue = this.playerBuffs[buffName] - 1;
                this.playerBuffs.Remove(buffName);
                this.playerBuffs.Add(buffName, newBuffValue);
                if (this.playerBuffs[buffName] == 0)
                {
                    Console.WriteLine("buff ended");
                    if (this.player is Fighter)
                    {
                        ((Fighter)this.player).Debuff(buffName);
                    }

                    if (this.player is Archer)
                    {
                        ((Archer)this.player).Debuff();
                    }

                    if (this.player is Mage)
                    {
                        ((Mage)this.player).Debuff();
                    }

                    this.playerBuffs.Remove(buffName);
                }
            }
        }

        private void MagicAttack(IAttackable victim)
        {
            this.ExecuteFighterCase(victim);

            this.ExecuteMageCase(victim);

            this.ExecuteArcherCase(victim);
        }

        private void ExecuteArcherCase(IAttackable victim)
        {
            if (this.player is Archer)
            {
                Console.WriteLine("Choose: multiShot, headShot, markTarget");
                var spell = Console.ReadLine();
                if (spell == null)
                {
                    return;
                }

                switch (spell.ToLower())
                {
                    case "multishot":
                        this.ExecuteMultiShotBuff(victim);
                        break;
                    case "headshot":
                        this.ExecuteHeadShotBuff(victim);
                        break;
                    case "marktarget":
                        this.ExecuteMarkTargetBuff();
                        break;
                }
            }
        }

        private void ExecuteMarkTargetBuff()
        {
            if (this.player.CurrentMana > ((Archer)this.player).MarkTargetManaCost)
            {
                Console.WriteLine("you buffed yourself");
                if (this.playerBuffs.ContainsKey("marktarget"))
                {
                    this.playerBuffs["marktarget"] = ((Archer)this.player).ArcherBuffTurnsOfEffect;
                }
                else
                {
                    ((Archer)this.player).MarkTargetBuff();
                    this.playerBuffs.Add("marktarget", ((Archer)this.player).ArcherBuffTurnsOfEffect);
                }
            }
            else
            {
                Console.WriteLine("no mana");
            }
        }

        private void ExecuteHeadShotBuff(IAttackable victim)
        {
            if (this.player.CurrentMana > ((Archer)this.player).HeadshotManaCost)
            {
                var dmgFromHeadshotSpell = ((Archer)this.player).HeadshotDamage();
                Console.WriteLine("you hit for {0} damage", dmgFromHeadshotSpell);
                victim.RespondToAttack(dmgFromHeadshotSpell);
            }
            else
            {
                Console.WriteLine("no mana");
            }
        }

        private void ExecuteMultiShotBuff(IAttackable victim)
        {
            if (this.player.CurrentMana > ((Archer)this.player).MultiShotManaCost)
            {
                var timesToAttack = ((Archer)this.player).MultiShotAttackTimes();
                for (var a = 0; a < timesToAttack; a++)
                {
                    var dmgFromPlayer = this.player.AttackDamage();
                    Console.WriteLine("you hit for {0} damage", dmgFromPlayer);
                    victim.RespondToAttack(dmgFromPlayer);
                }
            }
            else
            {
                Console.WriteLine("no mana");
            }
        }

        private void ExecuteMageCase(IAttackable victim)
        {
            if (this.player is Mage)
            {
                Console.WriteLine("Choose: frosShield, heal, flameStrike");
                var spell = Console.ReadLine();
                if (spell != null)
                {
                    switch (spell.ToLower())
                    {
                        case "frostshield":
                            this.ExecuteFrostShieldBuff();
                            break;
                        case "heal":
                            this.ExecuteHealBuff();
                            break;
                        case "flamestrike":
                            this.ExecuteFlameStrikeBuff(victim);
                            break;
                    }
                }
            }
        }

        private void ExecuteFlameStrikeBuff(IAttackable victim)
        {
            if (this.player.CurrentMana > ((Mage)this.player).MageHealManaCost)
            {
                var dmg = ((Mage)this.player).GetFlameStrikeDamage();
                victim.RespondToAttack(dmg);
                Console.WriteLine("you hit for {0} points", dmg);
            }
            else
            {
                Console.WriteLine("no mana");
            }
        }

        private void ExecuteHealBuff()
        {
            if (this.player.CurrentMana > ((Mage)this.player).MageHealManaCost)
            {
                ((Mage)this.player).HealEffects();
                Console.WriteLine("you healed");
            }
            else
            {
                Console.WriteLine("no mana");
            }
        }

        private void ExecuteFrostShieldBuff()
        {
            if (this.player.CurrentMana > ((Mage)this.player).MageFrostShieldManaCost)
            {
                Console.WriteLine("appliead frostSheld effects");

                if (this.playerBuffs.ContainsKey("frostSheld"))
                {
                    this.playerBuffs["frostSheld"] = ((Mage)this.player).MageFrostShieldTurnsOfEffect;
                }
                else
                {
                    (this.player as Mage).FrostShieldEffects();
                    this.playerBuffs.Add("frostSheld", ((Mage)this.player).MageFrostShieldTurnsOfEffect);
                }
            }
            else
            {
                Console.WriteLine("no mana");
            }
        }

        private void ExecuteFighterCase(IAttackable victim)
        {
            if (this.player is Fighter)
            {
                Console.WriteLine("Choose: damageBuff, bodyOfSteelBuff, HeavySlash");
                var spell = Console.ReadLine();
                if (spell != null)
                {
                    switch (spell.ToLower())
                    {
                        case "damagebuff":
                            this.ExecuteDamageBuff();
                            break;
                        case "bodyofsteel":
                            this.ExecuteBodyOfSteelBuff();
                            break;
                        case "heavyslash":
                            this.ExecuteHeavySplashBuff(victim);
                            break;
                    }
                }
            }
        }

        private void ExecuteHeavySplashBuff(IAttackable victim)
        {
            if (this.player.CurrentMana > ((Fighter)this.player).HeavySlashManaCost)
            {
                var dmg = ((Fighter)this.player).HeavySlashDamage();
                victim.RespondToAttack(dmg);
                Console.WriteLine("you hit for {0} points", dmg);
            }
            else
            {
                Console.WriteLine("no more mana buff faild");
            }
        }

        private void ExecuteBodyOfSteelBuff()
        {
            if (this.player.CurrentMana > ((Fighter)this.player).BodyOfSteelBuffManaCost)
            {
                Console.WriteLine("applied body of steel buff");
                if (this.playerBuffs.ContainsKey("DamageBuff"))
                {
                    this.playerBuffs["bodyofsteel"] = ((Fighter)this.player).BuffTurnsOfEffect;
                }
                else
                {
                    ((Fighter)this.player).ApplyBodyOfSteelBuff();
                    this.playerBuffs.Add("bodyofsteel", ((Fighter)this.player).BuffTurnsOfEffect);
                }
            }
            else
            {
                Console.WriteLine("buff faild");
            }
        }

        private void ExecuteDamageBuff()
        {
            if (this.player.CurrentMana > ((Fighter)this.player).DamageBuffManaCost)
            {
                Console.WriteLine("applied dmgBuff");
                if (this.playerBuffs.ContainsKey("DamageBuff"))
                {
                    this.playerBuffs["DamageBuff"] = ((Fighter)this.player).BuffTurnsOfEffect;
                }
                else
                {
                    ((Fighter)this.player).ApplyDamageBuff();
                    this.playerBuffs.Add("DamageBuff", ((Fighter)this.player).BuffTurnsOfEffect);
                }
            }
            else
            {
                Console.WriteLine("buff failed");
            }
        }

        #endregion

        private void RemoveDeadEnemies()
        {
            this.enemies.RemoveAll(enemy => enemy.CurrentHealth <= 0);
        }

        #region Command Executor

        private void ExecuteAttackCommand()
        {
            var sb = new StringBuilder();
            sb.Append("Choose who to attack: (");
            var enemyNames = new List<string>();
            this.enemies.ForEach(enemy => enemyNames.Add(enemy.Id));
            sb.Append(string.Join(", ", enemyNames));
            sb.Append(")");
            Console.WriteLine(sb.ToString());
        }

        private void ExecuteCommand(IReadOnlyList<string> args)
        {
            var action = args[0].ToLower();

            switch (action)
            {
                case "attack":
                    Console.WriteLine("Welcome to the battleground!");
                    this.player.Location = Location.Battleground;
                    string target;
                    do
                    {
                        this.ExecuteAttackCommand();
                        target = Console.ReadLine();
                    }
                    while (!this.CheckTargetInput(target));
                    this.AttackTarget(target);
                    break;

                case "inventory":
                    Console.Clear();
                    this.ExecuteInventoryCommand();

                    // Console.WriteLine(player.Inventory.Items.Count > 0 ? "Inventory: " + string.Join(", ", this.player.Inventory.Items) : "Inventory is empty");
                    break;

                case "equipment":
                    Console.WriteLine(this.player.EquipmentDetails());
                    break;

                case "stats":
                    Console.Clear();
                    Console.WriteLine(this.player.ShowStats());
                    break;

                case "movetoshop":
                    this.player.Location = Location.Shop;
                    this.ExecuteMoveToShopCommand();
                    break;

                case "save":
                    try
                    {
                        LoadFileManipulator.Save(this.player);
                        Console.WriteLine("Successfully saved!");
                    }
                    catch (SerializationException)
                    {
                        Console.Error.WriteLine("An error occurred while saving player");
                    }

                    break;

                case "load":
                    Console.WriteLine("Please enter name to load:");
                    this.player = LoadFileManipulator.Load(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine(this.player.ShowStats());
                    break;

                case "exit":
                    this.isRunning = false;
                    break;
            }
        }

        private void ExecuteInventoryCommand()
        {
            string commandLineToExecute = null;
            do
            {
                Console.WriteLine("Available commands: use/equip, unequip");
                var readLine = Console.ReadLine();
                if (readLine != null)
                {
                    commandLineToExecute = readLine.ToLower();
                }

                switch (commandLineToExecute)
                {
                    case "use":
                    case "equip":
                        this.ExecuteUseOrEquipCommand();
                        break;
                    case "unequip":
                        this.ExecuteUnequipCommand();
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }
            }
            while (commandLineToExecute != "exit");
        }

        private void ExecuteUnequipCommand()
        {
            if (this.player.Equipment.Count == 0)
            {
                Console.WriteLine("No equiped items");
            }
            else
            {
                var sb = new StringBuilder("Equiped items: \n");
                foreach (var slot in this.player.Equipment)
                {
                    sb.AppendFormat("{0}--->{1}", slot.Key, slot.Value);
                }

                Console.WriteLine(sb.ToString());

                var slotToUnequip = Console.ReadLine();
                if (slotToUnequip != null && this.player.Equipment.ContainsKey(slotToUnequip))
                {
                    this.player.Unequip(slotToUnequip);
                }
            }
        }

        private void ExecuteUseOrEquipCommand()
        {
            Console.Clear();
            var sb =
                new StringBuilder("Choose what to equip/use or use \"exit\":\n");
            if (this.player.Inventory.Items.Count > 0)
            {
                for (int i = 0; i < this.player.Inventory.Items.Count; i++)
                {
                    sb.AppendFormat("{0}--->{1}\n", i, this.player.Inventory.Items[i]);
                }
            }
            else
            {
                Console.WriteLine("No items in inventory");
                return;
            }

            Console.WriteLine(sb.ToString());

            var commandToExitOrItemIndex = Console.ReadLine();
            if (commandToExitOrItemIndex != null && commandToExitOrItemIndex.ToLower() == "exit")
            {
                return;
            }

            if (commandToExitOrItemIndex == null)
            {
                return;
            }

            try
            {
                var itemIndexToEquip = int.Parse(commandToExitOrItemIndex);
                var itemEquipped = this.player.Inventory.Items[itemIndexToEquip];
                this.player.Equip(itemEquipped);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid index");
            }
            catch (FormatException)
            {
                Console.WriteLine("You must enter a number!");
            }
            catch (AlreadyEquippedException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Item does not exist");
            }
        }

        private void ExecuteMoveToShopCommand()
        {
            Console.WriteLine("Welcome to the shop! Choose a command: (Buy, Sell)");
            var command = Console.ReadLine();

            while (command != null && command.ToLower() != "exit")
            {
                try
                {
                    this.ExecuteShopCommands(command);
                }
                catch (InsufficientMoneyException ex)
                {
                    Console.Error.WriteLine(ex.Message);
                }
                catch (InvalidOperationException)
                {
                    Console.Error.WriteLine("Item does not exist!");
                }
                catch (ArgumentException ex)
                {
                    Console.Error.WriteLine(ex.Message);
                }

                Console.WriteLine("Welcome to the shop! Choose a command: (Buy, Sell)");
                command = Console.ReadLine();
            }
        }

        private void ExecuteShopCommands(string command)
        {
            var optionsToBuy = string.Join("\n", this.shop.ItemsOnShop);
            var optionsToSell = string.Join("\n", this.player.Inventory);
            switch (command.ToLower())
            {
                case "buy":
                    Console.WriteLine(optionsToBuy);
                    var itemToBuy = Console.ReadLine();
                    var itemBought = this.shop.ItemsOnShop.First(t => t.Id.ToLower() == itemToBuy);
                    this.player.Buy(itemBought);
                    Console.WriteLine("Item bought: {0}", itemBought);
                    break;

                case "sell":
                    Console.WriteLine(optionsToSell);
                    var itemToSell = Console.ReadLine();
                    var itemSold = this.player.Inventory.Items.First(t => t.Id.ToLower() == itemToSell);
                    this.player.Sell(itemSold);
                    Console.WriteLine("Item sold: {0}", itemSold);
                    break;
            }
        }

        #endregion
    }
}