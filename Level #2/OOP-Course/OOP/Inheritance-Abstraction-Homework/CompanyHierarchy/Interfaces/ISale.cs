namespace CompanyHierarchy.Interfaces
{
    using System;

    interface ISale
    {
        string ProductName { get; }
        string Date { get; }
        decimal Price { get; }
    }
}
