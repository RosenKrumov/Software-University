namespace BidSystem.RestServices.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CreateOfferBindingModel
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal InitialPrice { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }
    }
}