using System;
using System.Linq;

namespace DatabaseFirstMappings
{
    public class DatabaseFirstMappings
    {
        static void Main()
        {
            var context = new FootballEntities();
            var teamNames = context.Teams
                .Select(t => t.TeamName);

            foreach (var teamName in teamNames)
            {
                Console.WriteLine(teamName);
            }
        }
    }
}
