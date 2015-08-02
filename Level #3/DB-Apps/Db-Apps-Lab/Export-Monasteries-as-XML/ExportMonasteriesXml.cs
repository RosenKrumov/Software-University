using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using EF_Mappings;

namespace Export_Monasteries_as_XML
{
    public class ExportMonasteriesXml
    {
        static void Main()
        {
            var context = new GeographyEntities();
            var countries = context.Countries
                .Where(c => c.Monasteries.Any())
                .OrderBy(c => c.CountryName)
                .Select(c => new
                {
                    c.CountryName,
                    Monasteries = c.Monasteries
                        .OrderBy(m => m.Name)
                        .Select(m => m.Name)
                });

            var xmlMonasteries = new XElement("monasteries");

            foreach (var country in countries)
            {
                var xmlCountry = new XElement("country");
                xmlCountry.Add(new XAttribute("name", country.CountryName));
                xmlMonasteries.Add(xmlCountry);

                foreach (var monastery in country.Monasteries)
                {
                    xmlCountry.Add(new XElement("monastery", monastery));
                }
            }

            var xmlDoc = new XDocument(xmlMonasteries);
            xmlDoc.Save("../../monasteries.xml");
        }
    }
}
