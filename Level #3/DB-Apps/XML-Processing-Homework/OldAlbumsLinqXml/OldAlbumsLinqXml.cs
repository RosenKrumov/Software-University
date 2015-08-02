namespace OldAlbumsLinqXml
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class OldAlbumsLinqXml
    {
        static void Main()
        {
            var document = XDocument.Load("../../../01_Catalog.xml");
            var albums = document
                .Elements("albums")
                .Elements("album")
                .Where(a => DateTime.Now.Year - Convert.ToInt32(a.Attribute("year").Value) >= 5)
                .Select(a => new
                {
                    Title = a.Attribute("name").Value,
                    Price = a.Attribute("price").Value
                })
                .ToList();

            foreach (var album in albums)
            {
                Console.WriteLine("Album: {0} - {1} lv", 
                    album.Title,
                    album.Price);    
            }
        }
    }
}