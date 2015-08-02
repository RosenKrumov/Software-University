using System;
using System.Linq;

namespace DatabaseFirst
{
    public class DatabaseFirst
    {
        static void Main()
        {
            var context = new PhotographySystemEntities();
            var cameras = context.Cameras
                .OrderBy(c => c.Manufacturer.Name + " " +  c.Model)
                .Select(c => new
                {
                    Name = c.Manufacturer.Name + " " + c.Model
                });

            foreach (var camera in cameras)
            {
                Console.WriteLine(camera.Name);
            }
        }
    }
}
