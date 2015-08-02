namespace ExtractArtistsNumberOfAlbums
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    public class ExtractArtistsNumberOfAlbums
    {
        static void Main()
        {
            var numberOfAlbumsByArtist = new Dictionary<string, int>();
            
            var document = new XmlDocument();
            document.Load("../../../01_Catalog.xml");
            var albums = document.DocumentElement;

            foreach (XmlNode album in albums)
            {
                var artist = album.Attributes["artist"].Value;

                if (!numberOfAlbumsByArtist.ContainsKey(artist))
                {
                    numberOfAlbumsByArtist[artist] = 1;
                }
                else
                {
                    numberOfAlbumsByArtist[artist]++;
                }
            }

            foreach (var artist in numberOfAlbumsByArtist)
            {
                Console.WriteLine("{0} - {1} albums",
                    artist.Key, artist.Value);
            }
        }
    }
}
