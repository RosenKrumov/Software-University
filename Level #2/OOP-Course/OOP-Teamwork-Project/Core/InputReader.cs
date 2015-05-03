namespace TeamworkProject.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using ConsoleApplication1.Models.Races;
    using Models.Races;

    public class InputReader
    {
        public static Dictionary<string, string> ReadInputForPlayer()
        {
            var playerOutput = new Dictionary<string, string>();

            var nameString = ReadNameInput();
            playerOutput["name"] = nameString;

            var raceString = ReadRaceInput();
            playerOutput["race"] = raceString;

            var roleString = ReadRoleInput();
            playerOutput["role"] = roleString;

            return playerOutput;
        }

        public static string ReadRoleInput()
        {
            var counter = 0;
            string roleString;

            do
            {
                if (counter > 0)
                {
                    Console.WriteLine("Invalid role.\n");
                }

                counter++;
                Console.WriteLine("Choose a role: (Archer, Fighter, Mage)");
                roleString = Console.ReadLine();
            } 
            while (!CheckRole(roleString));

            return roleString;
        }

        public static string ReadRaceInput()
        {
            var counter = 0;
            string raceString;

            do
            {
                if (counter > 0)
                {
                    Console.WriteLine("Invalid race.\n");
                }

                counter++;
                Console.WriteLine("Choose a race: (Human, Orc, Elf)");
                raceString = Console.ReadLine();
            } 
            while (ParseRaceFromString(raceString) == null);

            return raceString;
        }

        public static string ReadNameInput()
        {
            var counter = 0;
            string nameString;

            do
            {
                if (counter > 0)
                {
                    Console.Error.WriteLine("Invalid name.\n");
                }

                counter++;
                Console.WriteLine("Enter your name: ");
                nameString = Console.ReadLine();
            } 
            while (nameString != null && (nameString.Length < 3 || nameString.Contains(" ") || string.IsNullOrEmpty(nameString)));

            return nameString;
        }

        public static Race ParseRaceFromString(string race)
        {
            switch (race.ToLower())
            {
                case "human":
                    return new HumanRace();
                case "orc":
                    return new OrcRace();
                case "elf":
                    return new ElfRace();
                default:
                    return null;
            }
        }

        public static bool CheckRole(string roleString)
        {
            switch (roleString.ToLower())
            {
                case "archer":
                case "fighter":
                case "mage":
                    return true;
                default:
                    return false;
            }
        }

        public static string[] ExtractArgs(string command)
        {
            var args = Regex.Split(command, @"\s+");
            return args;
        }
    }
}