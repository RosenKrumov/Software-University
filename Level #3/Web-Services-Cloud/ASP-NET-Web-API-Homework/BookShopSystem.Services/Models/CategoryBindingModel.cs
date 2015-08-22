using System.ComponentModel.DataAnnotations;

namespace BookShopSystem.Services.Models
{
    public class CategoryBindingModel
    {
        [Required]
        public string Name { get; set; }
    }
}