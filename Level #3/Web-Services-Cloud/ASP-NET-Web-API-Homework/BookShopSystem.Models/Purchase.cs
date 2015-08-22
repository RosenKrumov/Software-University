using System;
using System.ComponentModel.DataAnnotations;

namespace BookShopSystem.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }

        public ApplicationUser User { get; set; }

        public Book Book { get; set; }

        public decimal Price { get; set; }
        
        public DateTime PurchaseDate { get; set; }

        public bool IsRecalled { get; set; }
    }
}