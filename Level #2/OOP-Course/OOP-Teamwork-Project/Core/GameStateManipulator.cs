namespace ConsoleApplication1.Core
{
    using System;
    using System.IO;
    using TeamworkProject.Core;

    public static class GameStateManipulator
    {
        public static string InteractWithConsoleForPlayerLoad()
        {
            var userInput = string.Empty;
            while (userInput != "yes" && userInput != "no")
            {
                Console.WriteLine("Do you want to load game? Yes or No?");
                userInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(userInput))
                {
                    userInput = userInput.ToLower();
                }
            }

            return userInput;
        }

        public static void PrintSavedGames()
        {
            Console.Clear();
            string[] fileEntries;

            Console.WriteLine("Players saved:");

            try
            {
                fileEntries = LoadFileManipulator.CheckForSavedGames();
            }
            catch (FileNotFoundException e)
            {
                throw new FileNotFoundException(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                throw new DirectoryNotFoundException(e.Message);
            }

            if (fileEntries != null)
            {
                for (var i = 0; i < fileEntries.Length; i++)
                {
                    var name = fileEntries[i].Remove(fileEntries[i].Length - 4, 4);
                    var place = name.LastIndexOf("\\", StringComparison.Ordinal);
                    var r = name.Substring(place + 1, name.Length - place - 1);
                    Console.Write(r);
                    if (fileEntries.Length - 1 != i)
                    {
                        Console.Write(", ");
                    }
                }

                Console.WriteLine();    
            }
        }

        public static string GetPlayerNameForLoad()
        {
            Console.WriteLine("Choose player:");
            var playerName = Console.ReadLine();
            Console.WriteLine("Loaded player:" + playerName);
            return playerName;
        }
    }
}
