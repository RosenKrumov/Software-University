namespace TeamworkProject.Core
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using Models.Characters;

    public static class LoadFileManipulator
    {
        public static string[] FileEntries { get; private set; }
        
        public static void Save(Player player)
        {
            if (player == null)
            {
                return;
            }

            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\Saved\\"))
            {
                var directoryInfo = Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Saved\\");
            }

            var bf = new BinaryFormatter();
            FileStream file = File.Open(Directory.GetCurrentDirectory() + "\\Saved\\" + player.Id + ".txt", FileMode.Create);

            try
            {
                bf.Serialize(file, player);
            }
            catch (SerializationException e)
            {
                throw e;
            }
            finally
            {
                file.Close();                
            }
        }

        public static Player Load(string playerName)
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\Saved\\" + playerName + ".txt"))
            {
                throw new ArgumentNullException("There is no saved state about this player.");
            }

            var bf = new BinaryFormatter();
            FileStream file = File.Open(Directory.GetCurrentDirectory() + "\\Saved\\" + playerName + ".txt", FileMode.Open);
            try
            {
                if (file.Length == 0)
                {
                    throw new NullReferenceException("The file is corrupt or empty");
                }

                var player = (Player)bf.Deserialize(file);
                return player;
            }
            catch (SerializationException e)
            {
                throw e;
            }
            finally
            {
                file.Close();                
            }
        }

        public static string[] CheckForSavedGames()
        {
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\Saved\\"))
            {
                throw new DirectoryNotFoundException("No such directory.");
            }
        
            FileEntries = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Saved\\");

            if (FileEntries.Length == 0)
            {
                throw new FileNotFoundException("There are no saved states of the game");
            }

            return FileEntries;
        }
    }
}