namespace ExtractAlbumNames
{
    using System;
    using System.Xml;

    public class ExtractAlbumNames
    {
        static void Main()
        {
            var document = new XmlDocument();
            document.Load("../../../01_Catalog.xml");
            var albums = document.DocumentElement;

            Console.WriteLine("Albums:");
            int index = 1;

            foreach (XmlNode album in albums.ChildNodes)
            {
                Console.WriteLine("{0}) {1}",
                    index, 
                    album.Attributes["name"].InnerText);

                index++;
            }
        }
    }
}
