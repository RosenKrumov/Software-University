namespace SoftUniEntities
{
    using System;
    using System.Linq;

    public static class QueriesProblem4
    {
        private static readonly SoftUniEntities Context = new SoftUniEntities();

        public static void PrintNamesWithNativeQuery()
        {
            var sql = @"SELECT e.FirstName
                        FROM Employees e
                        JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID
                        JOIN Projects p ON p.ProjectID = ep.ProjectID
                        WHERE DATEPART(YEAR, p.StartDate) = 2002";

            var employees = Context.Database.SqlQuery<string>(sql).ToList();

            //employees.ToList()
            //    .ForEach(e => Console.WriteLine(e.FirstName));
        }

        public static void PrintNamesWithLinqQuery()
        {
            var employees = Context.Employees
                .Where(e => e.Projects.Any(p => p.StartDate.Year == 2002))
                .Select(e => e.FirstName)
                .ToList();
        }
    }
}
