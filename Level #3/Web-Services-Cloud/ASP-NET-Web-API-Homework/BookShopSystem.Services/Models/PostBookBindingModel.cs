using System;
using System.ComponentModel.DataAnnotations;
using BookShopSystem.Models;

namespace BookShopSystem.Services.Models
{
    public class PostBookBindingModel
    {
        [MinLength(1)]
        [MaxLength(50)]
        [Required]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }
        
        [Required]
        public decimal Price { get; set; }
        
        [Required]
        public int Copies { get; set; }

        [Required]
        public EditionType EditionType { get; set; }
        public AgeRestriction AgeRestriction { get; set; }
        public string ReleaseDate { get; set; }
        public string Categories { get; set; }
    }
}