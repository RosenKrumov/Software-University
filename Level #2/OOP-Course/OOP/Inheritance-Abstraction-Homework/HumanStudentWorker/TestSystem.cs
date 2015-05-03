namespace HumanStudentWorker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TestSystem
    {
        static void Main()
        {
            var students = new List<Student>
            {
                new Student("gosho", "goshev", "f82738"),
                new Student("pesho", "peshev", "f88227"),
                new Student("ginka", "ginkova", "f12394"),
                new Student("kosta", "kostov", "f72838"),
                new Student("gino", "ginev", "f99283"),
                new Student("peno", "penev", "f93823"),
                new Student("chocho", "chochev", "f81273"),
                new Student("koko", "ivanov", "f73732"),
                new Student("ivan", "kokov", "f82828"),
                new Student("fifo", "fofov", "f12383")
            };

            var workers = new List<Worker>()
            {
                new Worker("Ivan", "Kostov", 560M, 9),
                new Worker("Kosta", "Ivanov", 500M, 8),
                new Worker("Ivancho", "Ivanchev", 680.21M, 9.25),
                new Worker("Mariya", "Petkova", 788.50M, 12),
                new Worker("Mariyan", "Mihaylov", 998.24M, 19.5),
                new Worker("Chichko", "Parichko", 5000.14M, 2),
                new Worker("Pichko", "Charichko", 1050M, 8),
                new Worker("Kocho", "Kochev", 320.80M, 12),
                new Worker("Kiro", "Kirev", 680.12M, 10),
                new Worker("Rosko", "Roskov", 660, 15.22)
            };

            var sortedStudents = students.OrderBy(student => student.FacultyNumber).ToList();

            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student);
            }

            var sortedWorkers = workers.OrderBy(worker => worker.MoneyPerHour(5)).ToList();

            foreach (var worker in sortedWorkers)
            {
                Console.WriteLine(worker);
            }

            var humans = new List<Human>();
            humans.AddRange(students);
            humans.AddRange(workers);

            var sortedHumans = humans.OrderBy(human => human.FirstName).ThenBy(human => human.LastName).ToList();

            foreach (var human in sortedHumans)
            {
                Console.WriteLine(human);
            }

        }
    }
}
