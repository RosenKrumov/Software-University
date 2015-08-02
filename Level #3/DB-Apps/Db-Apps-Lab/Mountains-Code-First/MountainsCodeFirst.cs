using System;
using System.Data.Entity;
using System.Linq;

namespace Mountains_Code_First
{
    public class MountainsCodeFirst
    {
        static void Main()
        {
            Database.SetInitializer(
                new MountainsMigrationStrategy());

            var context = new MountainsContext();

            var countries = context.Countries
                .Select(c => new
                {
                    c.Name,
                    Mountains = c.Mountains.Select(m => new
                    {
                        m.Name,
                        m.Peaks
                    })
                });

            foreach (var country in countries)
            {
                Console.WriteLine("Country: " + country.Name);

                foreach (var mountain in country.Mountains)
                {
                    Console.WriteLine(" Mountain: " + mountain.Name);

                    foreach (var peak in mountain.Peaks)
                    {
                        Console.WriteLine("\t{0} ({1})",
                            peak.Name, peak.Elevation);
                    }
                }
            }
        }
    }
}
