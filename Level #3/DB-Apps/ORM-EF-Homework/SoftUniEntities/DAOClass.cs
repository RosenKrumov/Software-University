namespace SoftUniEntities
{
    using System.Data.Entity.Migrations;

    public static class DAOClass
    {
        private static readonly SoftUniEntities Context = new SoftUniEntities();

        public static void Add(Employees employee)
        {
            Context.Employees.Add(employee);
            Context.SaveChanges();
        }

        public static Employees FindByKey(object key)
        {
            var employee = Context.Employees.Find(key);
            return employee;
        }

        public static void Modify(Employees newEmployee)
        {
            var employee = Context.Employees.Find(newEmployee.EmployeeID);
            if (employee != null)
            {
                employee = newEmployee;
            }

            Context.Employees.AddOrUpdate(employee);
            Context.SaveChanges();
        }

        public static void Delete(Employees employeeToDelete)
        {
            var employee = Context.Employees.Find(employeeToDelete.EmployeeID);
            if (employee != null)
            {
                Context.Employees.Remove(employee);
                Context.SaveChanges();   
            }
        }
    }
}
