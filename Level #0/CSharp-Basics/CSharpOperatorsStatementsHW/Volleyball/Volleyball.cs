using System;

class Volleyball
{
    static void Main()
    {
        string leapOrNot = Console.ReadLine();
        int holidays = int.Parse(Console.ReadLine());
        int homeWeekends = int.Parse(Console.ReadLine());
        double sum;
        sum = homeWeekends + (48 - homeWeekends) * 3.0 / 4.0 + holidays * 2.0 / 3.0;
        if (leapOrNot == "leap")
        {
            sum += sum * 15.0 / 100.0;
        }
        Console.WriteLine((int)sum);
    }
}