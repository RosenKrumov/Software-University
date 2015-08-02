using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using DatabaseFirst;

namespace ExportManufacturersCamerasJson
{
    public class ExportManufacturersCamerasJson
    {
        static void Main()
        {
            var context = new PhotographySystemEntities();
            var manufacturersCameras = context.Manufacturers
                .OrderBy(m => m.Name)
                .Select(m => new
                {
                    m.Name,
                    cameras = m.Cameras
                        .OrderBy(c => c.Model)
                        .Select(c => new
                        {
                            c.Model,
                            c.Price
                        })
                });

            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(manufacturersCameras);
            File.WriteAllText("../../manufacturers-and-cameras.json", json);
        }
    }
}
