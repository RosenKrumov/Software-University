using System;

namespace NightlifeEntertainment.Models.Performances
{
    public class Theatre : Performance
    {
        public Theatre(string name, decimal basePrice, IVenue venue, DateTime startTime) 
            : base(name, basePrice, venue, startTime, PerformanceType.Theatre)
        {
        }

        protected override void ValidateVenue()
        {
            throw new NotImplementedException();
        }
    }
}
