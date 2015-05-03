namespace ProjectStructureSolutionAuthor.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Models;

    interface ISale
    {
        Item Item { get; }
        DateTime PurchaseDate { get; }
    }
}
