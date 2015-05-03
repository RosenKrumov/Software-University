using System;

class Cinema
{
    static void Main()
    {
        string type = Console.ReadLine();
        int rows = int.Parse(Console.ReadLine());
        int columns = int.Parse(Console.ReadLine());
        if (type == "Premiere")
        {
            Console.WriteLine("{0:F2} leva", rows * columns * 12);
        }

        else if (type == "Normal")
        {
            Console.WriteLine("{0:F2} leva", rows * columns * 7.50);
        }

        else if (type == "Discount")
        {
            Console.WriteLine("{0:F2} leva", rows * columns * 5);
        }
    }
}