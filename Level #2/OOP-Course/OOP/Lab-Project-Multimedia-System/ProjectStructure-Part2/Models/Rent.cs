namespace ProjectStructureSolutionAuthor.Models
{
    using System;
    using Interfaces;

    class Rent : IRent
    {
        private RentState rentStatus;
        private Item item;
        private DateTime returnDate;

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
		            throw new ArgumentNullException("Item must not be empty.");
	            }
                this.item = value;
            }
        }

        public RentState RentStatus
        {
            get
            {
                if (this.returnDate.Year > 1)
                {
                    return RentState.Returned;
                }
                else if (DateTime.Now > Deadline)
                {
                    this.rentStatus = RentState.Overdue;
                }
                else if (DateTime.Now < Deadline)
                {
                    this.rentStatus = RentState.Pending;
                }
                return this.rentStatus;
            }
        }

        public DateTime RentDate { get; set; }

        public DateTime Deadline { get; set; }

        public DateTime ReturnDate
        {
            get 
            {
                return DateTime.Now;
            }
            set
            {
                this.returnDate = value;
            }
        }

        public decimal CalcRentFine()
        {
            int timespan = Convert.ToInt32((ReturnDate - Deadline).TotalDays);
            decimal interest = (this.item.Price / 100);
            decimal fine = interest * timespan;
            return fine;
        }

        public void ReturnItem()
        {
            this.ReturnDate = DateTime.Now;
        }

        public Rent(Item item, DateTime rentDate, DateTime deadline)
            : this(item, rentDate)
        {
            this.Deadline = deadline;
        }

        public Rent(Item item, DateTime rentDate)
            : this(item)
        {
            this.RentDate = rentDate;
            this.Deadline = DateTime.Now.AddDays(30);
        }

        public Rent(Item item)
        {
            this.Item = item;
            this.RentDate = DateTime.Now;
            this.Deadline = DateTime.Now.AddDays(30);
        }
    }
}
