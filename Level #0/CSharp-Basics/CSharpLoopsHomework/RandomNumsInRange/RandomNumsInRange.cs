using System;

class RandomNumsInRange
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int min = int.Parse(Console.ReadLine());
        int max = int.Parse(Console.ReadLine());
        Random rnd = new Random();

        for (int i = 0; i < n; i++)
        {
            Console.Write(rnd.Next(min, max + 1) + " ");
        }
        
    }
}