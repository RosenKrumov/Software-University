using System;
using System.Linq;

class BiggestTriple
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        int[] inputInt = null;
        int remainingTriples = input.Length % 3;
        if (remainingTriples == 0)
        {
            inputInt = new int[input.Length];
        }
        else if (remainingTriples == 1)
        {
            inputInt = new int[input.Length + 2];
            inputInt[input.Length] = 0;
            inputInt[input.Length + 1] = 0;
        }
        else if (remainingTriples == 2)
        {
            inputInt = new int[input.Length + 1];
            inputInt[input.Length] = 0;
        }
        int[] sums = new int[inputInt.Length / 3];

        for (int i = 0; i < input.Length; i++)
        {
            inputInt[i] = Convert.ToInt32(input[i].ToString());
        }


        for (int i = 0, j = 1, k = 2, index = 0; i < inputInt.Length - remainingTriples; i += 3, j += 3, k += 3)
        {
            sums[index] = inputInt[i] + inputInt[j] + inputInt[k];
            index++;
        }

        int maxValue = sums.Max();
        int maxIndex = sums.ToList().IndexOf(maxValue);
        for (int i = sums.Length - 1; i >= 0; i--)
        {
            if (sums[i] == sums[maxIndex])
            {
                maxIndex = i;
            }
        }
        if (maxIndex == sums.Length - 1)
        {
            if (remainingTriples == 2)
            {
                for (int i = 3 * maxIndex; i < 3 * maxIndex + 2; i++)
                {
                    Console.Write(inputInt[i] + " ");
                }
            }

            else if (remainingTriples == 1)
            {
                for (int i = 3 * maxIndex; i < 3 * maxIndex + 1; i++)
                {
                    Console.Write(inputInt[i] + " ");
                }
            }

            else if (remainingTriples == 0)
            {
                for (int i = 3 * maxIndex; i < 3 * maxIndex + 3; i++)
                {
                    Console.Write(inputInt[i] + " ");
                }

            }
        }
        else
            {
                for (int i = 3 * maxIndex; i < 3 * maxIndex + 3; i++)
                {
                    Console.Write(inputInt[i] + " ");
                }
            }
    }
}