namespace OldAlbums
{
    using System;
    using System.Xml;

    public class OldAlbums
    {
        static void Main()
        {
            var document = new XmlDocument();
            document.Load("../../../01_Catalog.xml");
            var albums = document.SelectNodes("/albums/album");

            foreach (XmlNode album in albums)
            {
                var yearPublished = Convert.ToInt32(album.Attributes["year"].Value);
                if (DateTime.Now.Year - yearPublished >= 5)
                {
                    Console.WriteLine("Album: {0} - {1} lv",
                        album.Attributes["name"].Value,
                        album.Attributes["price"].Value);
                }
            }
        }
    }
}