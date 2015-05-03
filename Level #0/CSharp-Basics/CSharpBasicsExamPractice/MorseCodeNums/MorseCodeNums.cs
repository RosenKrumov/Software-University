using System;
using System.Linq;

class MorseCodeNums
{
    static void Main()
    {
        string input = Console.ReadLine();
        int[] inputInt = new int[input.Length];
        int nSum = 0;
        int matchings = 0;
        for (int i = 0; i < input.Length; i++)
        {
            inputInt[i] = Convert.ToInt32(input[i].ToString());
            nSum += inputInt[i];
        }
        int[] morseCodeNums = new int[6];
        
        Random rnd = new Random();
        int morseCodeProduct = 0;

        for (int d1 = 0; d1 < 6; d1++)
        {
            for (int d2 = 0; d2 < 6; d2++)
            {
                for (int d3 = 0; d3 < 6; d3++)
                {
                    for (int d4 = 0; d4 < 6; d4++)
                    {
                        for (int d5 = 0; d5 < 6; d5++)
                        {
                            for (int d6 = 0; d6 < 6; d6++)
                            {
                                morseCodeProduct = d1 * d2 * d3 * d4 * d5 * d6;
                                if (morseCodeProduct == nSum)
                                {
                                    Console.Write(new string('.', morseCodeNums[0]));
                                    Console.Write(new string('-', 5 - morseCodeNums[0]));
                                    Console.Write("|");
                                    Console.Write(new string('.', morseCodeNums[1]));
                                    Console.Write(new string('-', 5 - morseCodeNums[1]));
                                    Console.Write("|");
                                    Console.Write(new string('.', morseCodeNums[2]));
                                    Console.Write(new string('-', 5 - morseCodeNums[2]));
                                    Console.Write("|");
                                    Console.Write(new string('.', morseCodeNums[3]));
                                    Console.Write(new string('-', 5 - morseCodeNums[3]));
                                    Console.Write("|");
                                    Console.Write(new string('.', morseCodeNums[4]));
                                    Console.Write(new string('-', 5 - morseCodeNums[4]));
                                    Console.Write("|");
                                    Console.Write(new string('.', morseCodeNums[5]));
                                    Console.Write(new string('-', 5 - morseCodeNums[5]));
                                    Console.Write("|");
                                    Console.WriteLine();
                                    matchings++;
                                }
                            }
                        }
                    }
                }
            }
        }
        if (matchings == 0)
        {
            Console.WriteLine("No");
        }
        
    }
}
