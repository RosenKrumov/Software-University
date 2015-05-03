namespace HumanStudentWorker
{
    using System;

    class Worker : Human
    {
        private decimal weekSalary;
        private double workHoursPerDay;

        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Salary must be positive.");
                }
                this.weekSalary = value;
            }
        }

        public double WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Work hours must be positive.");
                }
                this.workHoursPerDay = value;
            }
        }

        public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal MoneyPerHour(int daysOfWeek)
        {
            decimal dailySalary = this.WeekSalary / daysOfWeek;
            decimal moneyPerHour = dailySalary / (decimal)workHoursPerDay;
            return moneyPerHour;
        }

        public override string ToString()
        {
            return base.ToString() +
                string.Format("Week salary: {0:F2}\nWork hours per day: {0:F1}\n", 
                              this.WeekSalary, this.WorkHoursPerDay);
        }
    }
}
