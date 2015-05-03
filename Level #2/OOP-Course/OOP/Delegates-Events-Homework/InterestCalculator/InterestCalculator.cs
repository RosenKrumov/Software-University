namespace InterestCalculator
{
    using System;

    public delegate decimal CalculateInterest(decimal money, double interest, int years);

    class InterestCalculator
    {
        private decimal money;
        private double interest;
        private CalculateInterest type;
        private int years;

        public InterestCalculator(decimal money, double interest, CalculateInterest type, int years)
        {
            this.Money = money;
            this.Interest = interest;
            this.Type = type;
            this.Years = years;
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Money must be positive");
                }
                this.money = value;
            }
        }

        public double Interest
        {
            get
            {
                return this.interest;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Interest must be positive");
                }
                this.interest = value;
            }
        }

        public CalculateInterest Type { get; set; }

        public int Years
        {
            get
            {
                return this.years;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Years must be positive.");
                }
                this.years = value;
            }
        }

        public override string ToString()
        {
            string output = string.Format("{0:F4}", this.Type(this.Money, this.Interest, this.Years));
            return output;
        }
    }
}
