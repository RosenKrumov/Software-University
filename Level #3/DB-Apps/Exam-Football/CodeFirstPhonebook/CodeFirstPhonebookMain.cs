using System;
using System.Linq;

namespace CodeFirstPhonebook
{
    public class CodeFirstPhonebookMain
    {
        static void Main()
        {
            var context = new PhonebookEntities();
            var contacts = context.Contacts
                .Select(c => new
                {
                    c.Name,
                    Phones = c.Phones.Select(p => new {p.PhoneNumber}),
                    Emails = c.Emails.Select(e => new {e.EmailAddress})
                });

            foreach (var contact in contacts)
            {
                Console.WriteLine(contact.Name);
                foreach (var email in contact.Emails)
                {
                    Console.WriteLine(email);
                }

                foreach (var phone in contact.Phones)
                {
                    Console.WriteLine(phone);
                }
            }
        }
    }
}
