using System;

class DiffBetweenDates
{
    static void Main()
    {
        DateTime start = DateTime.Parse(Console.ReadLine());
        DateTime end = DateTime.Parse(Console.ReadLine());        
        string format = "dd.MM.yyyy";
        Console.WriteLine(difference(start,end));

    }

    static int difference (DateTime start, DateTime end)
    {
        return (int)(end - start).TotalDays;
    }
}