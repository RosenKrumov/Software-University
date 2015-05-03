using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Student
{
    public class OtherProblems
    {
        static void Main()
        {
            List<Student> students = new List<Student>()
            {
                new Student("Georgi", "Peshev", 22, 28282, "0888832737", "peshev@abv.bg", new List<int>() {3, 4, 2, 2}, 2),
                new Student("Ivan", "Ivanov", 23, 24242, "+35922737377", "ivanov@mail.bg", new List<int>(){3, 3, 6, 6}, 5),
                new Student("Georgi", "Angelov", 29, 33814, "+359 2 763727", "abv@mail.com", new List<int>(){6, 6, 6}, 2)
            };

            //Problem4
            var studentsGroup2 =
                from student in students
                where student.GroupNumber == 2
                select student;

            //studentsGroup2.ToList().ForEach(student => Console.WriteLine(student));

            //Problem5
            var studentsNameSort =
                from student in students
                where student.FirstName.CompareTo(student.LastName) < 1
                select student;

            //studentsNameSort.ToList().ForEach(student => Console.WriteLine(student));

            //Problem6
            var studentsByAge =
                from student in students
                where (student.Age > 18 && student.Age < 24)
                select new
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Age = student.Age
                };

            //studentsByAge.ToList().ForEach(student => Console.WriteLine(student));

            //Problem7
            var studentsFirstLastName =
                students.OrderBy(student => student.FirstName)
                    .ThenBy(student => student.LastName);

            var studentsFirstLastNameLINQ =
                from student in students
                orderby student.FirstName, student.LastName
                select student;

            //studentsFirstLastName.ToList().ForEach(student => Console.WriteLine(student));
            //studentsFirstLastNameLINQ.ToList().ForEach(student => Console.WriteLine(student));

            //Problem8
            var studentsEmailEnd =
                students.FindAll(student => student.Email.EndsWith("@abv.bg"));

            var studentsEmailEndLINQ =
                from student in students
                where student.Email.EndsWith("@abv.bg")
                select student;

            //studentsEmailEnd.ToList().ForEach(student => Console.WriteLine(student));
            //studentsEmailEndLINQ.ToList().ForEach(student => Console.WriteLine(student));

            //Problem9
            var studentsPhoneStart =
                students.FindAll(student => student.Phone.StartsWith("02") ||
                                            student.Phone.StartsWith("+3592") ||
                                            student.Phone.StartsWith("+359 2"));

            var studentsPhoneStartLINQ =
                from student in students
                where (student.Phone.StartsWith("02") ||
                       student.Phone.StartsWith("+3592") ||
                       student.Phone.StartsWith("+359 2"))
                select student;

            //studentsPhoneStart.ToList().ForEach(student => Console.WriteLine(student));
            //studentsPhoneStartLINQ.ToList().ForEach(student => Console.WriteLine(student));

            //Problem10
            var excellentStudents =
                students.Select(student => new {student.FirstName, student.LastName, student.Marks})
                    .Where(student => student.Marks.Contains(6));

            var excellentStudentsLINQ =
                from student in students
                where student.Marks.Contains(6)
                select new
                {
                    student.FirstName,
                    student.LastName,
                    student.Marks
                };

            //excellentStudents.ToList().ForEach(student => Console.WriteLine(student)); //Problem with printing the marks...
            //excellentStudents.ToList().ForEach(student => Console.WriteLine(student)); //Problem with printing the marks...

            //Problem11
            var weakStudents =
                students.FindAll(
                    student => student.Marks.Aggregate(0, (counter, mark) => counter + (mark == 2 ? 1 : 0)) == 2);

            //weakStudents.ToList().ForEach(student => Console.WriteLine(student));

            //Problem12
            var students2014 =
                students.FindAll(student => student.FacultyNumber%100 == 14);
            
            //students2014.ToList().ForEach(student => Console.WriteLine(student));

        }
    }
}