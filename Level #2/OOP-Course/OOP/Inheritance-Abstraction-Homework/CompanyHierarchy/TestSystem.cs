namespace CompanyHierarchy
{
    using System;
    using System.Collections.Generic;

    class TestSystem
    {

        //Dates are string in order not to display the time part 
        //from the whole date. That's the only way I managed to do this.
        static void Main()
        {
            List<Employee> penchoEmployees = new List<Employee>()
            {
                new Employee(10, "Petur", "Goshev", 990, Department.Marketing),
                new Employee(11, "Rosen", "Petrov", 999, Department.Marketing)
            };
            Manager pencho = new Manager(115, "Pencho", "Petrov", 1500, Department.Marketing, penchoEmployees);

            List<Employee> kirchoEmployees = new List<Employee>()
            {
                new Employee(20, "Gogo", "Gogov", 1990, Department.Accounting),
                new Employee(21, "Firo", "Firov", 1999, Department.Accounting)
            };
            Manager kircho = new Manager(116, "Kircho", "Kirchev", 1790, Department.Accounting, kirchoEmployees);

            List<Sale> kokoSales = new List<Sale>()
            {
                new Sale("Linux 15", DateTime.Today.AddDays(-150).Date.ToString("d"), 1680),
                new Sale("Acrobat Reader 9", DateTime.Today.AddDays(-120).Date.ToString("d"), 690)
            };
            SalesEmployee koko = new SalesEmployee(60, "Koko", "Kokov", 1500, Department.Sales, kokoSales);

            List<Project> nikiProjects = new List<Project>()
            {
                new Project("Online banking", DateTime.Today.AddDays(-40).Date.ToString("d"), "Expensive", ProjectState.Open),
                new Project("Mobile banking", DateTime.Today.AddDays(-80).Date.ToString("d"), "Mobility", ProjectState.Closed)
            };
            Developer niki = new Developer(90, "Niki", "Nikov", 2500, Department.Production, nikiProjects);

            List<Person> people = new List<Person>()
            {
                pencho,
                kircho,
                koko,
                niki
            };

            //nikiProjects[0].CloseProject();
            //Console.WriteLine(nikiProjects[0]);

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}