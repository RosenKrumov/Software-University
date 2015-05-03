namespace ProjectStructureSolutionAuthor.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Models;

    interface IRent
    {
        Item Item { get; }
        RentState RentStatus { get; }
        DateTime RentDate { get; }
        DateTime Deadline { get; }
        DateTime ReturnDate { get; }
        decimal CalcRentFine();
    }
}
