using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using EF_Mappings;

namespace Import_Rivers_From_Xml
{
    public class ImportRiversFromXml
    {
        private static void Main()
        {
            var context = new GeographyEntities();
            var xmlDoc = XDocument.Load("../../Rivers.xml");
            var rivers = xmlDoc.XPathSelectElements("/rivers/river");
            foreach (var river in rivers)
            {
                string name = river.Element("name").Value;
                int length = int.Parse(river.Element("length").Value);
                string outFlow = river.Element("outflow").Value;

                int? drainageArea = null;
                if (river.Element("drainage-area") != null)
                {
                    drainageArea = int.Parse(river.Element("drainage-area").Value);
                }

                int? averageDischarge = null;
                if (river.Element("average-discharge") != null)
                {
                    averageDischarge =
                        int.Parse(river.Element("average-discharge").Value);
                }

                var xmlCountries = xmlDoc.XPathSelectElements("/rivers/river/countries/country");

                var countries = xmlCountries.Select(c => c.Value);

                var riverToAdd = new River
                {
                    RiverName = name,
                    Length = length,
                    Outflow = outFlow,
                    DrainageArea = drainageArea,
                    AverageDischarge = averageDischarge
                };

                foreach (var country in countries)
                {
                    var countryToAdd = context.Countries
                        .FirstOrDefault(c => c.CountryName == country);
                    riverToAdd.Countries.Add(countryToAdd);
                }
                
                context.Rivers.Add(riverToAdd);
            }

            context.SaveChanges();
        }
    }
}
