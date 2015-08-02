using System.Linq;
using System.Xml.Linq;
using DatabaseFirst;

namespace ExportPhotographsXml
{
    public class ExportPhotographsXml
    {
        static void Main()
        {
            var context = new PhotographySystemEntities();
            var photographs = context.Photographs
                .OrderBy(p => p.Title)
                .Select(p => new
                {
                    p.Title,
                    Category = p.Category.Name,
                    p.Link,
                    cameraMegapixels = p.Equipment.Camera.Megapixels,
                    cameraName = p.Equipment.Camera.Manufacturer.Name + " " + p.Equipment.Camera.Model,
                    lensPrice = p.Equipment.Lens.Price,
                    lensName = p.Equipment.Lens.Manufacturer.Name + " " + p.Equipment.Lens.Model
                });

            var xmlPhotographs = new XElement("photographs");

            foreach (var photograph in photographs)
            {
                var xmlPhotograph = new XElement("photograph",
                                        new XAttribute("title", photograph.Title));

                var xmlCategory = new XElement("category");
                xmlCategory.SetValue(photograph.Category);
                xmlPhotograph.Add(xmlCategory);

                var xmlLink = new XElement("link", photograph.Link);
                xmlPhotograph.Add(xmlLink);

                var xmlEquipment = new XElement("equipment");
                
                var xmlCamera = new XElement("camera", 
                        new XAttribute("megapixels", photograph.cameraMegapixels));
                xmlCamera.SetValue(photograph.cameraName);

                xmlEquipment.Add(xmlCamera);

                var xmlLens = new XElement("lens");
                xmlLens.SetValue(photograph.lensName);

                if (xmlLens.Attribute("price") != null)
                {
                    xmlLens.Add(new XAttribute("price", photograph.lensPrice));
                }

                xmlEquipment.Add(xmlLens);
                xmlPhotograph.Add(xmlEquipment);
                xmlPhotographs.Add(xmlPhotograph);
            }

            var document = new XDocument();
            document.Add(xmlPhotographs);
            document.Save("../../photographs.xml");
        }
    }
}
