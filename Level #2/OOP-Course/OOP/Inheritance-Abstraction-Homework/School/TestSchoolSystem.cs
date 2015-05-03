namespace School
{
    using System;
    using System.Collections.Generic;

    class TestSchoolSystem
    {
        static void Main()
        {
            var students = new List<Student>
            {
                new Student("Pesho", 100, "Informatics"),
                new Student("Gosho",200),
                new Student("Ivko",300),
            };

            var disciplines = new List<Disciplines>
            {
                new Disciplines("OOP", 15, students, "Important"),
                new Disciplines("JavaScript", 25, students),
                new Disciplines("Structures and Algorithms", 20, students),
            };

            var teachers = new List<Teacher>
            {
                new Teacher("Gosho", disciplines, "Mathematics"),
                new Teacher("Ivan", disciplines),
                new Teacher("Stoyan",disciplines),
            };

            StudentClasses firstClass = new StudentClasses("OOP", teachers, "Excellent class");
        }
    }
}
