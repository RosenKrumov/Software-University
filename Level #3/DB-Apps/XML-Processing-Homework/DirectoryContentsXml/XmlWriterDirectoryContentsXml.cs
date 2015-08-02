namespace DirectoryContentsXml
{
    using System.IO;
    using System.Xml.Linq;

    public class XmlWriterDirectoryContentsXml
    {
        public static XElement GetDirectoryXml(DirectoryInfo dir)
        {
            var info = new XElement("dir",
                            new XAttribute("name", dir.Name));

            foreach (var file in dir.GetFiles())
            {
                info.Add(new XElement("file",
                                new XAttribute("name", file.Name)));
            }

            foreach (var subDir in dir.GetDirectories())
            {
                info.Add(GetDirectoryXml(subDir));
            }

            return info;
        }

        static void Main()
        {
            string rootPath = "../../";
            var dir = new DirectoryInfo(rootPath);

            var doc = new XDocument(GetDirectoryXml(dir));

            doc.Save("../../directories.xml");
        }
    }
}
