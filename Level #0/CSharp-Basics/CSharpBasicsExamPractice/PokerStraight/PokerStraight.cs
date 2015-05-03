using System;

class PokerStraight
{
    static void Main()
    {
        int w = int.Parse(Console.ReadLine());

        int weightSum = 0;
        int hands = 0;

        for (int i = 1; i <= 10; i++)
        {
            for (int suits1 = 1; suits1 <= 4; suits1++)
            {
                for (int suits2 = 1; suits2 <= 4; suits2++)
                {
                    for (int suits3 = 1; suits3 <= 4; suits3++)
                    {
                        for (int suits4 = 1; suits4 <= 4; suits4++)
                        {
                            for (int suits5 = 1; suits5 <= 4; suits5++)
                            {
                                weightSum = 
                                    i * 10 + suits1 +
                                    (i + 1) * 20 + suits2 +
                                    (i + 2) * 30 + suits3 +
                                    (i + 3) * 40 + suits4 +
                                    (i + 4) * 50 + suits5;
                                if (weightSum == w)
                                {
                                    hands++;
                                }
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine(hands);
    }
}