using System;
using System.Linq;

class SortingNums
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] input = new int[n];

        for (int i = 0; i < n; i++)
        {
            input[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(input);
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(input[i]);
        }
    }
}