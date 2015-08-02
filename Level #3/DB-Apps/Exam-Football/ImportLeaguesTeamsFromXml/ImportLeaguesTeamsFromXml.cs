using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using DatabaseFirstMappings;

namespace ImportLeaguesTeamsFromXml
{
    public class ImportLeaguesTeamsFromXml
    {
        static void Main()
        {
            var context = new FootballEntities();
            var document = new XmlDocument();
            document.Load("../../leagues-and-teams.xml");
            var leagues = document.DocumentElement;
            var index = 1;
            foreach (XmlNode league in leagues.ChildNodes)
            {
                var leagueToAdd = new League();
                Console.WriteLine("Processing league #{0} ...", index);
                if (league.SelectSingleNode("league-name") != null)
                {
                    var leagueName = league.SelectSingleNode("league-name").InnerText;
                    leagueToAdd.LeagueName = leagueName;

                    if (!context.Leagues.Any(l => l.LeagueName == leagueName))
                    {
                        context.Leagues.Add(leagueToAdd);
                        Console.WriteLine("Created league: " + leagueName);
                    }
                    else
                    {
                        Console.WriteLine("Existing league: " + leagueName);
                    }
                }

                context.SaveChanges();

                if (league.SelectSingleNode("teams") != null)
                {
                    var teams = league.SelectSingleNode("teams");

                    foreach (XmlNode team in teams.ChildNodes)
                    {
                        var teamToAddToLeague = new Team
                        {
                            TeamName = team.Attributes["name"].Value
                        };

                        if (team.Attributes["country"] == null)
                        {
                            var teamName = team.Attributes["name"].Value;
                            context.Teams.Add(teamToAddToLeague);
                            Console.WriteLine("Created team: " + teamName + " (no country)");
                            context.SaveChanges();
                        }
                        else
                        {
                            var teamName = team.Attributes["name"].Value;
                            var country = team.Attributes["country"].Value;
                            var countryCode = context.Countries.First(c => c.CountryName == country).CountryCode;

                            teamToAddToLeague.CountryCode = countryCode;

                            if (!context.Teams.Any(t => t.TeamName == teamName && t.Country.CountryName == country))
                            {
                                context.Teams.Add(teamToAddToLeague);

                                Console.WriteLine("Created team: {0} ({1})",
                                    teamName,
                                    country);
                            }
                            else
                            {
                                Console.WriteLine("Existing team: {0} ({1})",
                                    teamName,
                                    country);
                            }
                            context.SaveChanges();
                        }

                        if (league.SelectSingleNode("league-name") != null)
                        {
                            var leagueToFill = context.Leagues.First(l => l.LeagueName == leagueToAdd.LeagueName);
                            if (leagueToFill.Teams.All(t => t.TeamName != teamToAddToLeague.TeamName))
                            {
                                leagueToFill.Teams.Add(teamToAddToLeague);
                                Console.WriteLine("Added team to league: {0} to league {1}",
                                    teamToAddToLeague.TeamName,
                                    leagueToAdd.LeagueName);
                            }
                            else
                            {
                                Console.WriteLine("Existing team in league: {0} belongs to {1}",
                                    teamToAddToLeague.TeamName,
                                    leagueToAdd.LeagueName);
                            }
                        }
                    }
                }

                index++;
            }
        }
    }
}
