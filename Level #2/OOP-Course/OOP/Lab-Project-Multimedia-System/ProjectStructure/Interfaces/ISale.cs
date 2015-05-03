using ProjectStructure.Items;
using System;
using System.Collections.Generic;

namespace ProjectStructure.Interfaces
{
    public interface ISale
    {
        public Item Item { get; }
        public DateTime PurchaseDate { get; }
    }
}
