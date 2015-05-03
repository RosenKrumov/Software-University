using ProjectStructure.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStructure.Interfaces
{
    public interface IRent
    {
        public Item Item { get; }
        public string RentState { get; }
        public DateTime RentDate { get; }
        public DateTime Deadline { get; }
        public decimal CalculateRentFine();
    }
}
