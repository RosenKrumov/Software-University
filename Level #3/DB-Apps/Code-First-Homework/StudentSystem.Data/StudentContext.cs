using StudentSystem.Data.Migrations;

namespace StudentSystem.Data
{
    using Models;
    using System.Data.Entity;

    public class StudentContext : DbContext
    {
        public StudentContext()
            : base("name=StudentContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentContext, Configuration>());
        }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Resource> Resources { get; set; }
    }
}