using System;
using System.Linq;

class LongestAreaArray
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] input = new string[n];
        int longestArea = 0;
        string stringLongestArea = "";
        for (int i = 0; i < n; i++)
        {
            input[i] = Console.ReadLine();
        }

        for (int i = 0; i < input.Length; i++)
        {
            int count = 0;
            for (int j = i; j < input.Length; j++)
            {
                if (input[i] == input[j])
                {
                    count++;
                    if (longestArea < count)
                    {
                        longestArea = count;
                        stringLongestArea = input[i];
                    }
                }
                else
                {
                    break;
                }
            }            
        }
        Console.WriteLine(longestArea);
        for (int i = 0; i < longestArea; i++)
        {
            Console.WriteLine(stringLongestArea);
        }
    }
}