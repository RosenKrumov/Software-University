using System;

class ExamSchedule
{
    static void Main()
    {
        int hours = int.Parse(Console.ReadLine());
        int minutes = int.Parse(Console.ReadLine());
        string partOfDay = Console.ReadLine();
        int hoursDuration = int.Parse(Console.ReadLine());
        int minutesDuration = int.Parse(Console.ReadLine());
        int hoursEnd = hours + hoursDuration;
        int minutesEnd = minutes + minutesDuration;
        
        if (minutesEnd >= 60)
        {
            minutesEnd -= 60;
            hoursEnd++;
        }

        if (hoursEnd >= 12)
        {
            if (hoursEnd > 12 && hoursEnd < 24)
            {
                hoursEnd -= 12;

            }
            else if (hoursEnd >= 24)
            {
                hoursEnd -= 24;
            }
            if (partOfDay == "AM")
            {
                partOfDay = "PM";
            }
            else if (partOfDay == "PM")
            {
                partOfDay = "AM";
            }
        }

        Console.Write(Convert.ToString(hoursEnd,10).PadLeft(2,'0'));
        Console.Write(":");
        Console.Write(Convert.ToString(minutesEnd, 10).PadLeft(2,'0'));
        Console.WriteLine(":{0}", partOfDay);
    }
}
}