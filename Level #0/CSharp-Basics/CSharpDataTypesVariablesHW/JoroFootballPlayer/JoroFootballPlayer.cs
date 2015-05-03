using System;
class JoroFootballPlayer
{
    static void Main()
    {
        string leapOrNot = Console.ReadLine();
        int holidays = int.Parse(Console.ReadLine());
        int hometownWeekends = int.Parse(Console.ReadLine());
        int sum;
        sum = holidays / 2 + hometownWeekends + (52 - hometownWeekends) * 2 / 3;
        if (leapOrNot == "t")
        {
            sum = sum + 3;
        }
        Console.WriteLine(sum);
    }
}