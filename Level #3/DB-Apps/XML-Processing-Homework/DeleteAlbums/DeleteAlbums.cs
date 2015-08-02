using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace DeleteAlbums
{
    public class DeleteAlbums
    {
        static void Main()
        {
            var document = new XmlDocument();
            document.Load("../../../01_Catalog.xml");
            var albums = document.DocumentElement;

            (
                from XmlNode album in albums 
                let price = album.Attributes["price"].Value 
                where Convert.ToDecimal(price) > 20m select album)
                .ToList()
                .ForEach(a => a.ParentNode.RemoveChild(a)
            );

            document.Save("../../../06_Cheap-albums-catalog.xml");
        }
    }
}
