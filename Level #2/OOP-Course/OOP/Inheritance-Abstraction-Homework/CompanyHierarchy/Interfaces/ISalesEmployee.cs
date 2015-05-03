namespace CompanyHierarchy.Interfaces
{
    using System.Collections.Generic;

    interface ISalesEmployee
    {
        List<Sale> Sales { get; }
    }
}
