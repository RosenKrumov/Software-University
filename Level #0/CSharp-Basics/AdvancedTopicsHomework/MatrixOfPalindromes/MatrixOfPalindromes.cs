using System;

class MatrixOfPalindromes
{
    static void Main()
    {
        string[] matrix = Console.ReadLine().Split(' ');
        int rows = Convert.ToInt32(matrix[0]);
        int cols = Convert.ToInt32(matrix[1]);

        for (char i = 'a'; i < (char)('a' + rows); i++)
        {
            for (char j = i; j < (char)(i + cols); j++)
            {
                Console.Write(i);
                Console.Write(j);
                Console.Write(i);
                Console.Write(" ");
            }
            Console.WriteLine();
        }

    }
}