using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace ExtractArtistsAlphabetically
{
    public class ExtractArtistsAlphabetically
    {
        static void Main()
        {
            var document = new XmlDocument();
            document.Load("../../../01_Catalog.xml");
            var albums = document.DocumentElement;

            Console.WriteLine("Artists:");

            (
                from XmlNode album in albums.ChildNodes 
                select album.Attributes["artist"].Value
            )
            .OrderBy(a => a)
            .ToList()
            .ForEach(Console.WriteLine);
        }
    }
}
