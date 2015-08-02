namespace SoftUniEntities
{
    using System;
    using System.Linq;
    public static class QueriesProblem3
    {
        private static readonly SoftUniEntities Context = new SoftUniEntities();

        public static void EmployeesProjectsBetweenYears()
        {
            var employees = Context.Employees
                .Where(e => e.Projects.Any(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerName = e.Employees2.FirstName + " " + e.Employees2.LastName,
                    e.Projects
                }).ToList();

            foreach (var employee in employees)
            {
                var projects = employee.Projects.Select(p => new
                {
                    p.Name,
                    p.StartDate,
                    p.EndDate
                });
                
                Console.Write(
                    "{0} {1} - Manager: {2}\n" +
                    "Projects:\n",
                    employee.FirstName,
                    employee.LastName,
                    employee.ManagerName
                );

                foreach (var project in projects)
                {
                    Console.Write( 
                        "Project name: {0}\n" +
                        "Start date: {1}\n" +
                        "End date: {2}\n",
                        project.Name,
                        project.StartDate,
                        project.EndDate
                    );
                }

                Console.WriteLine("-------------------");
            }
        }

        public static void EmployeesByAddresses()
        {
            var addresses = Context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Towns.Name)
                .Take(10)
                .Select(a => new
                {
                    a.AddressText,
                    Town = a.Towns.Name,
                    Employees = a.Employees.Count
                })
                .ToList();

            foreach (var address in addresses)
            {
                Console.WriteLine("Address: {0}\n" +
                                  "Town: {1}\n" +
                                  "Employees: {2}",
                                    address.AddressText,
                                    address.Town,
                                    address.Employees);
                Console.WriteLine("------------------");
            }
        }

        public static void ProjectsByEmployeeWithId()
        {
            var employeeWithProjects = Context.Employees
                .Where(e => e.EmployeeID == 147)
                .Select(e => new
                {
                    Name = e.FirstName + " " + e.LastName,
                    e.JobTitle,
                    e.Projects
                })
                .FirstOrDefault();

            if (employeeWithProjects != null)
            {
                Console.Write("{0} - {1}\n" +
                              "Projects:\n",
                              employeeWithProjects.Name,
                              employeeWithProjects.JobTitle);

                var projectsOfEmployee = employeeWithProjects
                    .Projects
                    .OrderBy(p => p.Name)
                    .Select(p => p.Name)
                    .ToList();
            
                projectsOfEmployee.ForEach(Console.WriteLine);
            }
        }

        public static void EmployeesByDepartment()
        {
            //Problem 3.4
            var departments = Context.Departments
                .Where(d => d.Employees1.Count > 5)
                .OrderBy(d => d.Employees1.Count)
                .Select(d => new
                {
                    d.Name,
                    ManagerName = d.Employees.FirstName + " " + d.Employees.LastName,
                    d.Employees1
                });

            foreach (var department in departments)
            {
                var departmentEmployees = department.Employees1
                    .Select(e => new
                    {
                        Name = e.FirstName + " " + e.LastName,
                        e.HireDate,
                        e.JobTitle
                    });

                Console.WriteLine("{0} - Manager: {1}, Employees: {2}",
                    department.Name,
                    department.ManagerName,
                    department.Employees1.Count());
            }
        }
    }
}
