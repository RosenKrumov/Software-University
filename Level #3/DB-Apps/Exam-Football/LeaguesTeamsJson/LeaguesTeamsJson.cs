using System;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using DatabaseFirstMappings;

namespace LeaguesTeamsJson
{
    public class LeaguesTeamsJson
    {
        static void Main()
        {
            var context = new FootballEntities();
            var leaguesTeams = context.Leagues
                .OrderBy(l => l.LeagueName)
                .Select(l => new
                {
                    l.LeagueName,
                    Teams = l.Teams
                        .OrderBy(t => t.TeamName)
                        .Select(t => t.TeamName)
                });

            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(leaguesTeams);
            File.WriteAllText("../../leagues-and-teams.json", json);
        }
    }
}
