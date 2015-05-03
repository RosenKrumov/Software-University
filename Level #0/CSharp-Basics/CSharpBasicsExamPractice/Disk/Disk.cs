using System;

class Disk
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int r = int.Parse(Console.ReadLine());
                 
        for (int row = - n/2; row <= n/2; row++)
        {
            for (int col = -n/2; col <= n/2; col++)
            {
                if (col*col + row*row <= r*r)
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