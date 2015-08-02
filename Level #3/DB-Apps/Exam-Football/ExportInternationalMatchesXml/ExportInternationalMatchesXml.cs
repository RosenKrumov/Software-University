using System;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace ExportInternationalMatchesXml
{
    using DatabaseFirstMappings;

    public class ExportInternationalMatchesXml
    {
        static void Main()
        {
            var context = new FootballEntities();
            var internationalMatches = context.InternationalMatches
                .OrderBy(im => im.MatchDate)
                .ThenBy(im => im.HomeCountry)
                .ThenBy(im => im.AwayCountry)
                .Select(im => new
                {
                    im.MatchDate,
                    HomeCountryName = im.HomeCountry.CountryName,
                    im.HomeCountryCode,
                    im.HomeGoals,
                    AwayCountryName = im.AwayCountry.CountryName,
                    im.AwayCountryCode,
                    im.AwayGoals,
                    im.League.LeagueName
                });

            var xmlMatches = new XElement("matches");

            foreach (var match in internationalMatches)
            {
                var xmlMatch = new XElement("match");
                if (match.MatchDate != null)
                {
                    if (Convert.ToDateTime(match.MatchDate)
                        .TimeOfDay.TotalSeconds != 0)
                    {
                        var matchdate =
                            Convert.ToDateTime(match.MatchDate)
                                .ToString("dd-MMM-yyyy hh:mm",                          CultureInfo.InvariantCulture);
                        xmlMatch.Add(new XAttribute("date-time", matchdate));
                    }
                    else
                    {
                        var matchdate =
                            Convert.ToDateTime(match.MatchDate)
                                .ToString("dd-MMM-yyyy",                                CultureInfo.InvariantCulture);
                        xmlMatch.Add(new XAttribute("date", matchdate));
                    }
                }

                var xmlHomeCountry = new XElement("home-country");
                xmlHomeCountry.Add(new XAttribute("code", match.HomeCountryCode));
                xmlHomeCountry.SetValue(match.HomeCountryName);

                var xmlAwayCountry = new XElement("away-country");
                xmlAwayCountry.Add(new XAttribute("code", match.AwayCountryCode));
                xmlAwayCountry.SetValue(match.AwayCountryName);

                xmlMatch.Add(xmlHomeCountry);
                xmlMatch.Add(xmlAwayCountry);

                if (match.HomeGoals.HasValue)
                {
                    var xmlScore = new XElement("score");
                    xmlScore.SetValue(match.HomeGoals + "-" + match.AwayGoals);
                    xmlMatch.Add(xmlScore);
                }

                if (match.LeagueName != null)
                {
                    var xmlLeague = new XElement("league");
                    xmlLeague.SetValue(match.LeagueName);
                    xmlMatch.Add(xmlLeague);
                }

                xmlMatches.Add(xmlMatch);
            }

            var document = new XDocument();
            document.Add(xmlMatches);
            document.Save("../../international-matches.xml");
        }
    }
}
