using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSystem.Data;

namespace StudentSystem.ConsoleClient
{
    public static class QueriesProblem3
    {
        private static readonly StudentContext Context = new StudentContext();

        public static void PrintStudentsHomeworks()
        {
            var studentsHomeworks = Context.Students
                .Select(s => new
                {
                    Name = s.FirstName + " " + s.LastName,
                    s.Homeworks
                })
                .ToList();

            foreach (var student in studentsHomeworks)
            {
                Console.WriteLine("Student: {0}\n" +
                                  "Homeworks:",
                                  student.Name);
                if (!student.Homeworks.Any())
                {
                    Console.WriteLine("No homeworks");
                }
                else
                {
                    foreach (var homework in student.Homeworks.Select(h => new { h.Content, h.ContentType }))
                    {
                        Console.WriteLine("Content: {0}\n" +
                                          "Type: {1}\n" +
                                          "--------------",
                                          homework.Content,
                                          homework.ContentType);
                    }
                    Console.WriteLine("**********");
                }
            }
        }

        public static void PrintCoursesResources()
        {
            var coursesResources = Context.Courses
                .Select(c => new
                {
                    c.Name,
                    c.Description,
                    c.Resources
                })
                .ToList();

            foreach (var course in coursesResources)
            {
                Console.WriteLine("Course: {0}\n" +
                                  "Description: {1}\n" +
                                  "Resources:",
                                  course.Name,
                                  course.Description);
                if (!course.Resources.Any())
                {
                    Console.WriteLine("No resources");
                }
                else
                {
                    foreach (var resource in course.Resources)
                    {
                        Console.WriteLine("Name: {0}\n" +
                                          "Type: {1}\n" +
                                          "Url: {2}\n" +
                                          "--------------",
                                          resource.Name,
                                          resource.ResourceType,
                                          resource.Url);
                    }
                    Console.WriteLine("**********");
                }
            }
        }

        public static void PrintCoursesMoreThanFiveResources()
        {
            var courses = Context.Courses
                .Where(c => c.Resources.Count > 5)
                .OrderByDescending(c => c.Resources.Count)
                .ThenByDescending(c => c.StartDate)
                .Select(c => new
                {
                    c.Name,
                    Resources = c.Resources.Count
                })
                .ToList();

            if (courses.Any())
            {
                foreach (var course in courses)
                {
                    Console.WriteLine(course.Name);
                }
            }
            else
            {
                Console.WriteLine("No courses with more than 5 resources");
            }
        }

        public static void PrintActiveCoursesWithStudents()
        {
            var givenDate = Convert.ToDateTime("01/02/2010");
            var courses = Context.Courses
                .Where(c => c.StartDate <= givenDate && c.EndDate >= givenDate)
                .OrderByDescending(c => c.Students.Count)
                .ThenByDescending(c => DbFunctions.DiffDays(c.StartDate, c.EndDate))
                .Select(c => new
                {
                    c.Name,
                    c.StartDate,
                    c.EndDate,
                    Duration = DbFunctions.DiffDays(c.StartDate, c.EndDate),
                    StudentsEnrolled = c.Students.Count
                });

            foreach (var course in courses)
            {
                Console.WriteLine("Course Name: {0}\n" +
                                  "Start Date: {1}\n" +
                                  "End Date: {2}\n" +
                                  "Duration: {3} days\n" +
                                  "Students Enrolled: {4}",
                                  course.Name,
                                  course.StartDate.ToShortDateString(),
                                  course.EndDate.ToShortDateString(),
                                  course.Duration,
                                  course.StudentsEnrolled);
            }
        }

        public static void PrintStudentCoursesAndPrices()
        {
            var coursesByStudent = Context.Students
                .OrderByDescending(s => s.Courses.Sum(c => c.Price))
                .ThenByDescending(s => s.Courses.Count)
                .ThenBy(s => s.FirstName + " " + s.LastName)
                .Select(s => new
                {
                    Name = s.FirstName + " " + s.LastName,
                    CoursesCount = s.Courses.Count,
                    TotalPrice = s.Courses.Select(c => c.Price).Sum(),
                    AvgPrice = s.Courses.Select(c => c.Price).Average()
                })
                .ToList();

            foreach (var student in coursesByStudent)
            {
                Console.WriteLine("Student: {0}\n" +
                                  "Courses: {1}\n" +
                                  "Total Price: {2}\n" +
                                  "Average Price: {3:F2}\n" +
                                  "-----------",
                                  student.Name,
                                  student.CoursesCount,
                                  student.TotalPrice,
                                  student.AvgPrice);
            }
        }
    }
}
