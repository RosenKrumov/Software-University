using System;

class MatrixOfNums
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1, k = i; j <= n; j++, k++)
            {
                Console.Write(k + " ");
                
            }
            Console.WriteLine();
        }
    }
}