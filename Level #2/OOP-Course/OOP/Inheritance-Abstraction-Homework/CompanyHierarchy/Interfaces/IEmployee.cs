namespace CompanyHierarchy.Interfaces
{
    interface IEmployee
    {
        decimal Salary { get; }
        Department Department { get; }
    }
}
