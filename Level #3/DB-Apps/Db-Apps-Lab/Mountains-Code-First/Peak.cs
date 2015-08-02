using System.ComponentModel.DataAnnotations;

namespace Mountains_Code_First
{
    public class Peak
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Elevation { get; set; }

        public virtual Mountain Mountain { get; set; }
    }
}
