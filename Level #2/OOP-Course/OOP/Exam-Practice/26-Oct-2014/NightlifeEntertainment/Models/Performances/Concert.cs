namespace NightlifeEntertainment.Models.Performances
{
    using System;

    public class Concert : Performance
    {
        public Concert(string name, decimal basePrice, IVenue venue, DateTime startTime) 
            : base(name, basePrice, venue, startTime, PerformanceType.Concert)
        {
        }

        protected override void ValidateVenue()
        {
            throw new NotImplementedException();
        }
    }
}
