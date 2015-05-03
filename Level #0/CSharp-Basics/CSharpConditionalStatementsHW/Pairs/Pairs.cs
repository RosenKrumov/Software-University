using System;
using System.Linq;

class Pairs
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        int[] inputInt = new int[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            inputInt[i] = Convert.ToInt32(input[i].ToString());
        }
        
        int[] sums = new int[inputInt.Length / 2];
        int index = 0;
        for (int i = 0; i < inputInt.Length / 2; i++)
        {
            
            int sum = inputInt[index] + inputInt[index + 1];
            index += 2;
            sums[i] = sum;

        }
        bool subSums = true;
        int diff = 0;
        int maxDiff = 0;
        for (int i = 0; i < sums.Length - 1; i++)
        {
                if (sums[i] != sums[i + 1])
                {
                    subSums = false;
                    diff = Math.Abs(sums[i] - sums[i + 1]);
                    if (diff > maxDiff)
                    {
                        maxDiff = diff;
                    }
                }
        }

        
        if (subSums == true)
        {
            Console.WriteLine("Yes, value={0}", sums[0]);
        }

        else
        {
            Console.WriteLine("No, maxdiff=" + Math.Abs(maxDiff));
        }
    }
}