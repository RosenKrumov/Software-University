using System.Collections.Generic;
using StudentSystem.Models;

namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "StudentSystem.Data.StudentContext";
        }

        protected override void Seed(StudentContext context)
        {
            var resource1 = new Resource
            {
                Name = "Lectures",
                ResourceType = ResourceType.Presentation,
                Url = "www.coolsite.com"
            };

            var resource2 = new Resource
            {
                Name = "Videos",
                ResourceType = ResourceType.Video,
                Url = "www.youtube.com"
            };

            var resource3 = new Resource
            {
                Name = "Forum",
                ResourceType = ResourceType.Other,
                Url = "www.foruma.com"
            };

            var resource4 = new Resource
            {
                Name = "Homeworks",
                ResourceType = ResourceType.Document,
                Url = "www.zadachi.com"
            };

            if (!context.Resources.Any())
            {
                var resources = new List<Resource> { resource1, resource2, resource3, resource4 };
                resources.ForEach(r => context.Resources.AddOrUpdate(r));    
            }

            var homework1 = new Homework
            {
                Content = "asdasd",
                ContentType = ContentType.ApplicationPdf,
                SubmissionDate = DateTime.Today.AddDays(-123)
            };

            var homework2 = new Homework
            {
                Content = "asdasdasd",
                ContentType = ContentType.ApplicationZip,
                SubmissionDate = DateTime.Today.AddDays(-12)
            };

            var homework3 = new Homework
            {
                Content = "asdasdqwe",
                ContentType = ContentType.ApplicationPdf,
                SubmissionDate = DateTime.Today.AddDays(-100)
            };

            var homework4 = new Homework
            {
                Content = "asdasdqx",
                ContentType = ContentType.ApplicationZip,
                SubmissionDate = DateTime.Today.AddDays(-55)
            };

            if (!context.Homeworks.Any())
            {
                var homeworks = new List<Homework> { homework1, homework2, homework3, homework4 };
                homeworks.ForEach(h => context.Homeworks.AddOrUpdate(h));
            }

            var course1 = new Course
            {
                Name = "C# Basics",
                Description = "Programming Basics Course",
                StartDate = Convert.ToDateTime("01/01/2010"),
                EndDate = Convert.ToDateTime("01/03/2010"),
                Price = 0m
            };
            course1.Homeworks.Add(homework1);
            course1.Homeworks.Add(homework2);
            course1.Resources.Add(resource1);
            course1.Resources.Add(resource2);

            var course2 = new Course
            {
                Name = "Java Basics",
                Description = "Java Fundamentals",
                StartDate = Convert.ToDateTime("03/03/2010"),
                EndDate = Convert.ToDateTime("03/05/2010"),
                Price = 100m
            };
            course2.Homeworks.Add(homework3);
            course2.Homeworks.Add(homework4);
            course2.Resources.Add(resource3);
            course2.Resources.Add(resource4);

            if (!context.Courses.Any())
            {
                var courses = new List<Course> { course1, course2 };
                courses.ForEach(c => context.Courses.AddOrUpdate(c));
            }

            var student1 = new Student
            {
                FirstName = "Pesho",
                LastName = "Goshow",
                PhoneNumber = "0888123123",
                RegistrationDate = DateTime.Now.AddMonths(-14)
            };

            student1.Courses.Add(course1);
            student1.Courses.Add(course2);
            student1.Homeworks.Add(homework1);
            student1.Homeworks.Add(homework2);
            student1.Homeworks.Add(homework3);

            var student2 = new Student
            {
                FirstName = "Gosho",
                LastName = "Peshew",
                PhoneNumber = "0888123121",
                RegistrationDate = DateTime.Now.AddMonths(-10)
            };

            student2.Courses.Add(course2);
            student2.Homeworks.Add(homework4);

            if (!context.Students.Any())
            {
                var students = new List<Student> { student1, student2 };
                students.ForEach(s => context.Students.AddOrUpdate(s));
            }
            
            context.SaveChanges();
        }
    }
}
