using System;
using System.Linq;

namespace StudentSystem.Data
{
    public static class Helper
    {
        public static void SeedRelationsData(StudentContext context)
        {
            var random = new Random();

            foreach (var course in context.Courses)
            {
                for (int i = 0; i < 3; i++)
                {
                    var randomResourceIndex = random.Next(0, context.Resources.Count());
                    var resource = context.Resources.Find(randomResourceIndex);
                    course.Resources.Add(resource);
                }
            }

            foreach (var course in context.Courses)
            {
                for (int i = 0; i < 3; i++)
                {
                    var randomHomeworkIndex = random.Next(0, context.Homeworks.Count());
                    var homework = context.Homeworks.Find(randomHomeworkIndex);
                    course.Homeworks.Add(homework);
                }
            }

            foreach (var student in context.Students)
            {
                for (int i = 0; i < 3; i++)
                {
                    var randomHomeworkIndex = random.Next(0, context.Homeworks.Count());
                    var randomCourseIndex = random.Next(0, context.Courses.Count());
                    var course = context.Courses.Find(randomCourseIndex);
                    var homework = context.Homeworks.Find(randomHomeworkIndex);
                    student.Courses.Add(course);
                    student.Homeworks.Add(homework);
                }
            }

            context.SaveChanges(); //That adding does not work in the Seed() method and I do not know why...
        }
    }
}
