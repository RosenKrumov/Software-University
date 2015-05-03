namespace CompanyHierarchy.Interfaces
{
    using System.Collections.Generic;

    interface IDeveloper
    {
        List<Project> Projects { get; }
    }
}
