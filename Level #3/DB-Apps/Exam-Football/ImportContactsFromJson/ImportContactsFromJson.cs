namespace ImportContactsFromJson
{
    using System;
    using System.IO;
    using System.Web.Script.Serialization;
    using CodeFirstPhonebook;
    using Newtonsoft.Json.Linq;

    public class ImportContactsFromJson
    {
        static void Main()
        {
            var context = new PhonebookEntities();
            var json = File.ReadAllText("../../contacts.json");
            var contacts = JArray.Parse(json);
            var serializer = new JavaScriptSerializer();

            foreach (var contact in contacts.Children<JObject>())
            {
                var dbContact = new Contact();

                if (contact["name"] == null)
                {
                    Console.WriteLine("Error: Name is required");
                    continue;
                }

                dbContact.Name = contact["name"].ToString();

                if (contact["company"] != null)
                {
                    dbContact.Company = contact["company"].ToString();
                }

                if (contact["position"] != null)
                {
                    dbContact.Position = contact["position"].ToString();
                }

                if (contact["site"] != null)
                {
                    dbContact.Website = contact["site"].ToString();
                }

                if (contact["notes"] != null)
                {
                    dbContact.Notes = contact["notes"].ToString();
                }

                if (contact["phones"] != null)
                {
                    foreach (var phone in contact["phones"])
                    {
                        dbContact.Phones.Add(new Phone { PhoneNumber = phone.ToString() });
                    }
                }

                if (contact["emails"] != null)
                {
                    foreach (var email in contact["emails"])
                    {
                        dbContact.Emails.Add(new Email { EmailAddress = email.ToString() });
                    }
                }

                context.Contacts.Add(dbContact);
                context.SaveChanges();
                Console.WriteLine("Contact {0} imported", dbContact.Name);
            }
        }
    }
}
