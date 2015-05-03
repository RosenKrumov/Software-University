using System;

class MelonsWatermelons
{
    static void Main()
    {
        int startingDay = int.Parse(Console.ReadLine());
        int days = int.Parse(Console.ReadLine());
        int melons = 0;
        int watermelons = 0;
        int remainingDays;
        int fullWeeks = days / 7;
        melons += fullWeeks * 7;
        watermelons += fullWeeks * 7;
        remainingDays = days - fullWeeks * 7;
        for (int i = startingDay; i < startingDay + remainingDays; i++)
        {
            switch (i % 7)
            {
                case 1:
                    watermelons++;
                    break;
                case 2:
                    melons += 2;
                    break;
                case 3:
                    watermelons++;
                    melons++;
                    break;
                case 4:
                    watermelons += 2;
                    break;
                case 5:
                    watermelons += 2;
                    melons += 2;
                    break;
                case 6:
                    watermelons++;
                    melons += 2;
                    break;
                default:
                    break;
            }
        }
        if (watermelons > melons)
        {
            Console.WriteLine("{0} more watermelons", watermelons - melons);
        }
        else if (melons > watermelons)
        {
            Console.WriteLine("{0} more melons", melons - watermelons);
        }
        else if (melons == watermelons)
        {
            Console.WriteLine("Equal amount: {0}", melons);
        }
    }
}