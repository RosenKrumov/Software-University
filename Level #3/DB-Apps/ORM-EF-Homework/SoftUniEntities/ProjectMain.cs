namespace SoftUniEntities
{
    using System;
    using System.Diagnostics;

    class ProjectMain
    {
        static void Main()
        {
            //Problem 3.1
            //QueriesProblem3.EmployeesProjectsBetweenYears();

            //Problem 3.2
            //QueriesProblem3.EmployeesByAddresses();

            //Problem 3.3
            //QueriesProblem3.ProjectsByEmployeeWithId();

            //Problem 3.4
            //QueriesProblem3.EmployeesByDepartment();

            //Problem 4
            //var sw = new Stopwatch();
            //sw.Start();
            //QueriesProblem4.PrintNamesWithNativeQuery();
            //Console.WriteLine("Native: {0}", sw.Elapsed);
            //sw.Restart();
            //QueriesProblem4.PrintNamesWithLinqQuery();
            //Console.WriteLine("Linq: {0}", sw.Elapsed);
            //sw.Stop();

            //Problem 6
            //var context = new SoftUniEntities();
            //var projects = context.usp_ProjectsByEmployee("Ruth", "Ellerbrock");

            //foreach (var project in projects)
            //{
            //    Console.WriteLine("{0} - {1}, {2}",
            //                        project.Name,
            //                        project.Description.Substring(0, 30) + "...",
            //                        project.StartDate);
            //}
        }
    }
}
