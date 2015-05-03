using System;

class StudentCables
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int countUsedCables = 0;
        int usedCableLength = 0;

        for (int i = 0; i < n; i++)
        {
            int currentCable = int.Parse(Console.ReadLine());
            string units = Console.ReadLine();

            if ((units == "centimeters") && (currentCable >= 20))
            {
                countUsedCables++;
                usedCableLength += currentCable;
            }

            else if (units == "meters")
            {
                countUsedCables++;
                usedCableLength += (currentCable * 100);
            }
        }

        int usedCableLengthCut = (usedCableLength - (countUsedCables - 1) * 3);

        int studentCables = usedCableLengthCut / 504;
        int remainingCable = usedCableLengthCut % 504;

        Console.WriteLine(studentCables);
        Console.WriteLine(remainingCable);
    }
}