using System;

class Tables
{
    static void Main()
    {
        long bundle1Packets = long.Parse(Console.ReadLine());
        long bundle2Packets = long.Parse(Console.ReadLine());
        long bundle3Packets = long.Parse(Console.ReadLine());
        long bundle4Packets = long.Parse(Console.ReadLine());
        long tops = long.Parse(Console.ReadLine());
        long tablesToMade = long.Parse(Console.ReadLine());

        long legs = bundle1Packets + (2 * bundle2Packets) + (3 * bundle3Packets) + (4 * bundle4Packets);
        long tablesMade = tops;
        long legsLeft = legs - 4 * tablesToMade;
        long legsNeeded = ((tablesToMade - tablesMade) * 4) - legsLeft;
        if (tablesMade > tablesToMade)
        {
            Console.WriteLine("more: {0}", tablesMade - tablesToMade);
            Console.Write("tops left: {0}, ", tablesMade - tablesToMade);
            Console.WriteLine("legs left: {0}", legsLeft);
        }
        else if (tablesMade < tablesToMade)
        {
            Console.WriteLine("less: {0}", tablesMade - tablesToMade);
            Console.Write("tops needed: {0}, ", Math.Abs(tablesMade - tablesToMade));
            if (legsLeft > 0)
            {
                Console.WriteLine("legs needed: 0");
            }
            else
            {
                Console.WriteLine("legs needed: {0}", legsNeeded);
            }
        }
        else if (tablesMade == tablesToMade && tablesMade == legs / 4)
        {
            Console.WriteLine("Just enough tables made: {0}", tablesMade);
        }
        else if (tablesMade == tablesToMade && tablesMade != legs / 4)
        {
            Console.WriteLine("less: {0}", legs/4 - tablesToMade);
            Console.Write("tops needed: 0, ");
            Console.WriteLine("legs needed: {0}", Math.Abs(legs % 4 - 4));
        }
    }

}