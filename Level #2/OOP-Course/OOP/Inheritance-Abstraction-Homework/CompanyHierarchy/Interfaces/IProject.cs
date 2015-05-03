namespace CompanyHierarchy.Interfaces
{
    using System;

    interface IProject
    {
        string Name { get; }
        string StartDate { get; }
        string Details { get; }
        ProjectState State { get; }
    }
}
