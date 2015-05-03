using System;

class RandomizeNums
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] input = new int[n];
        Random rnd = new Random();

        for (int i = 0; i < input.Length; i++)
        {
            input[i] = rnd.Next(input.Length);
        }

        for (int i = 0; i < input.Length; i++)
        {
            Console.Write(i + " ");
        }
    }
}