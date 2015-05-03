using System;

class EmployeeData
{
    static void Main()
    {
        string firstName = "Rosen";
        string lastName = "Krumov";
        byte age = 18;
        char gender = 'm';
        long personalID = 8306112507;
        int uniqueNumber = 27562718;
        Console.WriteLine("Full name: " + firstName + " " + lastName);
        Console.WriteLine("Age: " + age);
        Console.WriteLine("Gender: " + gender);
        Console.WriteLine("Personal ID number: " + personalID);
        Console.WriteLine("Unique employee number: " + uniqueNumber);
    }
}