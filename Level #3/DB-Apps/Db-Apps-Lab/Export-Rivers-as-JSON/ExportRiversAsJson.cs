using System;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using EF_Mappings;

namespace Export_Rivers_as_JSON
{
    public class ExportRiversAsJson
    {
        static void Main()
        {
            var context = new GeographyEntities();
            var jsSerializer = new JavaScriptSerializer();
            var rivers = context.Rivers
                .OrderByDescending(r => r.Length)
                .Select(r => new
                {
                    r.RiverName,
                    r.Length,
                    Countries = r.Countries
                    .OrderBy(c => c.CountryName)
                    .Select(c => c.CountryName)
                });

            var riversJson = jsSerializer.Serialize(rivers.ToList());
            File.WriteAllText("../../rivers.json", riversJson);
        }
    }
}
