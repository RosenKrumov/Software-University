using System;

class WorkHours
{
    static void Main()
    {
        //input
        uint requiredHours = uint.Parse(Console.ReadLine());
        uint availableDays = uint.Parse(Console.ReadLine());
        uint productivity = uint.Parse(Console.ReadLine());

        //logic
        double workDays = availableDays - availableDays / 10.0;
        double workHours = workDays * 12;
        double efficientWorkHours = workHours * productivity/100;
        double difference = Math.Floor(efficientWorkHours - requiredHours);
        
        
        //output
        if (difference >= 0)
        {
            Console.WriteLine("Yes");
            Console.WriteLine(difference);
        }
        else
        {
            Console.WriteLine("No");
            Console.WriteLine(difference);
        }
        

    }
}