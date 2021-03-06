﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstPhonebook
{
    public class Contact
    {
        private ICollection<Email> emails;
        private ICollection<Phone> phones;

        public Contact()
        {
            this.emails = new HashSet<Email>();
            this.phones = new HashSet<Phone>();
        }
        
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Position { get; set; }
        
        public string Company { get; set; }

        public string Notes { get; set; }

        public string Website { get; set; }

        public ICollection<Email> Emails
        {
            get { return this.emails; }
            set { this.emails = value; }
        }

        public ICollection<Phone> Phones
        {
            get { return this.phones; }
            set { this.phones = value; }
        }
    }
}
