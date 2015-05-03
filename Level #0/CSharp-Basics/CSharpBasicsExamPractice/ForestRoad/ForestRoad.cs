using System;

class ForestRoad
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int col = 0; col < 2 * n - 1; col++)
        {
            for (int row = 0; row < n; row++)
            {
                if (col == row || col == 2*n - row - 2)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }
    }
}