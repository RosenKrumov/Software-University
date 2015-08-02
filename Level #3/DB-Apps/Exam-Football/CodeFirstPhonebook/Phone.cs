using System.ComponentModel.DataAnnotations;

namespace CodeFirstPhonebook
{
    public class Phone
    {
        [Key]
        public int Id { get; set; }

        public string PhoneNumber { get; set; }
    }
}
