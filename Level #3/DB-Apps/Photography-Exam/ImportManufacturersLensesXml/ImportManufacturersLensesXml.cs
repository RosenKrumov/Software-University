using System;
using System.Linq;
using System.Xml;
using DatabaseFirst;

namespace ImportManufacturersLensesXml
{
    public class ImportManufacturersLensesXml
    {
        static void Main()
        {
            var context = new PhotographySystemEntities();
            var document = new XmlDocument();
            document.Load("../../manufacturers-and-lenses.xml");
            var manufacturers = document.DocumentElement;
            var index = 1;

            foreach (XmlNode manufacturer in manufacturers.ChildNodes)
            {
                Console.WriteLine("Processing manufacturer {0}", index++);

                var manufacturerToAdd = new Manufacturer();
                var manufacturerName = manufacturer.SelectSingleNode("manufacturer-name").InnerText;
                manufacturerToAdd.Name = manufacturerName;

                if (!context.Manufacturers.Any(m => m.Name == manufacturerName))
                {
                    context.Manufacturers.Add(manufacturerToAdd);
                    Console.WriteLine("Created manufacturer: {0}", manufacturerName);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Existing manufacturer: {0}", manufacturerName);
                }

                if (manufacturer.SelectSingleNode("lenses") != null)
                {
                    var lenses = manufacturer.SelectSingleNode("lenses");

                    if (lenses.SelectSingleNode("lens") != null)
                    {
                        foreach (XmlNode lens in lenses.ChildNodes)
                        {
                            var lensModel = lens.Attributes["model"].Value;

                            var lensToAddToManufacturer = new Lens
                            {
                                Model = lensModel,
                                Type = lens.Attributes["type"].Value
                            };

                            if (lens.Attributes["price"] != null)
                            {
                                var price = Convert.ToDecimal(lens.Attributes["price"].Value);
                                lensToAddToManufacturer.Price = price;
                            }

                            if (!context.Lenses.Any(l => l.Model == lensModel))
                            {
                                context.Lenses.Add(lensToAddToManufacturer);
                                Console.WriteLine("Created lens: {0}", lensModel);
                            }
                            else
                            {
                                Console.WriteLine("Existing lens: {0}",
                                    lensModel);
                            }

                            context.SaveChanges();

                            if (manufacturer.SelectSingleNode("manufacturer-name") != null)
                            {
                                var manufacturerToFill = context.Manufacturers.First(m => m.Name == manufacturerToAdd.Name);
                                if (manufacturerToFill.Lenses.All(l => l.Model != lensToAddToManufacturer.Model))
                                {
                                    manufacturerToFill.Lenses.Add(lensToAddToManufacturer);
                                    Console.WriteLine("Lens added to manufacturer: {0} to manufacturer {1}",
                                        lensToAddToManufacturer.Model,
                                        manufacturerToFill.Name);
                                    context.SaveChanges();
                                }
                                else
                                {
                                    Console.WriteLine("Existing lens in manufacturer: {0} belongs to manufacturer {1}",
                                        lensToAddToManufacturer.Model,
                                        manufacturerToFill.Name);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
