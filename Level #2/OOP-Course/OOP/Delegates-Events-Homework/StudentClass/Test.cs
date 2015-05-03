namespace StudentClass
{
    using System;

    public class Test
    {
        static void Main()
        {
            Student student = new Student("Pesho", 16);
            student.Name = "Misho";
            student.Age = 15;
        }
    }
}
