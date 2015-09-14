namespace Scoreboard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class Scoreboard
    {
        private const string UserRegistered = "User registered";
        private const string DuplicatedUser = "Duplicated user";
        private const string GameRegistered = "Game registered";
        private const string DuplicatedGame = "Duplicated game";
        private const string CannotAddScore = "Cannot add score";
        private const string ScoreAdded = "Score added";
        private const string GameNotFound = "Game not found";
        private const string NoScore = "No score";
        private const string NoMatches = "No matches";
        private const string CannotDeleteGame = "Cannot delete game";
        private const string GameDeleted = "Game deleted";

        private readonly Dictionary<string, User> usersByUsername = 
            new Dictionary<string, User>();
        private readonly Dictionary<string, Game> gamesByName = 
            new Dictionary<string, Game>();
        private readonly Dictionary<string, OrderedDictionary<string, List<int>>> scoresByGame = 
            new Dictionary<string, OrderedDictionary<string, List<int>>>();

        public string ProcessCommand(string command)
        {
            int indexOfFirstSpace = command.IndexOf(' ');
            string method = command.Substring(0, indexOfFirstSpace);
            string parameterValues = command.Substring(indexOfFirstSpace + 1);
            string[] parameters =
                parameterValues.Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            switch (method)
            {
                case "RegisterUser":
                    return this.RegisterUser(parameters[0], parameters[1]);
                case "RegisterGame":
                    return this.RegisterGame(parameters[0], parameters[1]);
                case "AddScore":
                    return this.AddScore(parameters[0], parameters[1], parameters[2], parameters[3], int.Parse(parameters[4]));
                case "ShowScoreboard":
                    return this.ShowScoreboard(parameters[0]);
                case "ListGamesByPrefix":
                    return this.ListGamesByPrefix(parameters[0]);
                case "DeleteGame":
                    return this.DeleteGame(parameters[0], parameters[1]);
                default:
                    return string.Empty;
            }
        }
		
		private string RegisterUser(string username, string password)
        {
            if (!this.usersByUsername.ContainsKey(username))
            {
                var user = new User()
                {
                    Username = username,
                    Password = password
                };
                
                this.usersByUsername[username] = user;
                return UserRegistered;
            }

            return DuplicatedUser;
        }

        private string RegisterGame(string name, string password)
        {
            if (!this.gamesByName.ContainsKey(name))
            {
                var game = new Game()
                {
                    Name = name,
                    Password = password
                };

                this.gamesByName[name] = game;
                return GameRegistered;
            }

            return DuplicatedGame;
        }

        private string AddScore(string username, string password, string gameName, string gamePassword, int score)
        {
            if (!this.usersByUsername.ContainsKey(username) || !this.gamesByName.ContainsKey(gameName))
            {
                return CannotAddScore;
            }

            var user = this.usersByUsername[username];
            var game = this.gamesByName[gameName];

            if (user.Password != password || game.Password != gamePassword)
            {
                return CannotAddScore;
            }

            this.scoresByGame.EnsureKeyExists(gameName);
            this.scoresByGame[gameName].AppendValueToKey(username, score);

            return ScoreAdded;
        }

        private string ShowScoreboard(string gameName)
        {
            if (!this.gamesByName.ContainsKey(gameName))
            {
                return GameNotFound;
            }

            if (!this.scoresByGame.ContainsKey(gameName))
            {
                return NoScore;
            }

            var scores = this.scoresByGame[gameName].OrderBy(p => p.Key);

            var pairs = (from pair in scores from score in pair.Value select new KeyValuePair<string, int>(pair.Key, score)).ToList();

            var output = pairs
                .OrderByDescending(p => p.Value)
                .Take(10);

            var id = 1;
            var builder = new StringBuilder();
            foreach (var pair in output)
            {
                builder.AppendLine(string.Format("#{0} {1} {2}", id, pair.Key, pair.Value));
                id++;
            }

            builder.Length -= Environment.NewLine.Length;
            return builder.ToString().TrimEnd();
        }

        private string ListGamesByPrefix(string prefix)
        {
            var games = this.gamesByName.Values.Where(v => v.Name.StartsWith(prefix)).OrderBy(g => g.Name).Select(g => g.Name).Take(10).ToList();

            return games.Count > 0 ? string.Join(", ", games) : NoMatches;
        }

        private string DeleteGame(string gameName, string password)
        {
            if (!this.gamesByName.ContainsKey(gameName))
            {
                return CannotDeleteGame;
            }

            var game = this.gamesByName[gameName];

            if (game.Password != password)
            {
                return CannotDeleteGame;
            }

            this.gamesByName.Remove(gameName);
            this.scoresByGame.Remove(gameName);

            return GameDeleted;
        }
    }
}
