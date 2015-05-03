using System;

class Electricity
{
    static void Main()
    {
        int floors = int.Parse(Console.ReadLine());
        int flats = int.Parse(Console.ReadLine());
        DateTime time = DateTime.Parse(Console.ReadLine());
        if (time.Hour >= 14 && time.Hour < 19)
        {
            double sum = (2 * 100.53 + 2 * 125.9) * flats * floors;
            Console.WriteLine("{0} Watts", (int)sum);
        }

        else if (time.Hour >= 19 && time.Hour < 24)
        {
            double sum = (7 * 100.53 + 6 * 125.9) * flats * floors;
            Console.WriteLine("{0} Watts", (int)sum);
        }

        else if (time.Hour >= 0 && time.Hour < 9)
        {
            double sum = (100.53 + 8 * 125.9) * flats * floors;
            Console.WriteLine("{0} Watts", (int)sum);
        }

        else
        {
            Console.WriteLine("0 Watts");
        }
    }
}