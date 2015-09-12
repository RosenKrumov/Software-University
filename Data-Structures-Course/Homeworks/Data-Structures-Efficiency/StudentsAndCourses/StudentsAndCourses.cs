namespace StudentsAndCourses
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class StudentsAndCourses
    {
        private static readonly IDictionary<string, SortedSet<Person>> peopleByCourse = 
            new SortedDictionary<string, SortedSet<Person>>(); 

        public static void Main()
        {
            var textLines = File.ReadAllLines("../../students.txt");
            foreach (var textLine in textLines)
            {
                var tokens = textLine.Split(new[] {'|'}, StringSplitOptions.RemoveEmptyEntries);
                var firstName = tokens[0].Trim();
                var lastName = tokens[1].Trim();
                var course = tokens[2].Trim();
                var person = new Person(){FirstName = firstName, LastName = lastName};

                if (!peopleByCourse.ContainsKey(course))
                {
                    peopleByCourse[course] = new SortedSet<Person>();
                }

                peopleByCourse[course].Add(person);
            }

            foreach (var pair in peopleByCourse)
            {
                Console.WriteLine("{0}: {1}", pair.Key, string.Join(", ", pair.Value));
            }
        }
    }
}
