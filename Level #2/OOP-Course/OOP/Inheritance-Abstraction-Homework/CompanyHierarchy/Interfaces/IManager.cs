namespace CompanyHierarchy.Interfaces
{
    using System.Collections.Generic;

    interface IManager
    {
        List<Employee> Employees { get; }
    }
}
