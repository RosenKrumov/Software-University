using System.ComponentModel.DataAnnotations;

namespace CodeFirstPhonebook
{
    public class Email
    {
        [Key]
        public int Id { get; set; }

        public string EmailAddress { get; set; }
    }
}
