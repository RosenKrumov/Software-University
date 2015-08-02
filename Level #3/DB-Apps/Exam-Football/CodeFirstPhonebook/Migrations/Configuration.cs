namespace CodeFirstPhonebook.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PhonebookEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PhonebookEntities context)
        {
            if (!context.Contacts.Any())
            {
                context.Contacts.Add(new Contact
                {
                    Name = "Peter Ivanov",
                    Position = "CTO",
                    Company = "Smart Ideas",
                    Emails =
                    {
                        new Email { EmailAddress = "peter@gmail.com" }, 
                        new Email { EmailAddress = "peter_ivanov@yahoo.com" }
                    },
                    Phones =
                    {
                        new Phone { PhoneNumber = "+359 2 22 22 22" },
                        new Phone { PhoneNumber = "+359 88 77 88 99"}
                    },
                    Website = "http://blog.peter.com",
                    Notes = "Friend from school"
                });

                context.Contacts.Add(new Contact
                {
                    Name = "Maria",
                    Phones = { new Phone { PhoneNumber = "+359 22 33 44 55"} }
                });

                context.Contacts.Add(new Contact
                {
                    Name = "Angie Stanton",
                    Emails =
                    {
                        new Email {EmailAddress = "info@angiestanton.com"}
                    },
                    Website = "http://angiestanton.com"
                });

                context.SaveChanges();
            }
        }
    }
}
