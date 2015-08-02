using System;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Models
{
    public class Homework
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public ContentType ContentType { get; set; }

        public DateTime SubmissionDate { get; set; }
    }
}
