namespace ProjectStructureSolutionAuthor.Models
{
    using System;
    using Models;

    class Sale
    {
        private Item item;
        private DateTime saleDate;

        public Item Item
        {
            get
            {
                return this.item;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Sale item must not be empty.");
                }
                this.item = value;
            }
        }

        public DateTime SaleDate { get; set; }

        public Sale(Item item, DateTime saleDate)
            : this(item)
        {
            this.SaleDate = saleDate;
        }

        public Sale(Item item)
        {
            this.Item = item;
            this.SaleDate = DateTime.Now;
        }
    }
}
