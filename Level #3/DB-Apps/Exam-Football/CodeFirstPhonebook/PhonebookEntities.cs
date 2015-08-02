using CodeFirstPhonebook.Migrations;

namespace CodeFirstPhonebook
{
    using System.Data.Entity;

    public class PhonebookEntities : DbContext
    {
        public PhonebookEntities()
            : base("name=PhonebookEntities")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhonebookEntities, Configuration>());
        }

        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Email> Emails { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
    }
}