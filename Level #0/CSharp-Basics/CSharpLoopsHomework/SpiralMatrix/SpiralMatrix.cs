using System;

class SpiralMatrix
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        int row = 0;
        int col = 0;
        string side = "right";
        for (int i = 1; i <= n * n; i++)
        {
            if (side == "right" && (col > n - 1 || matrix[row,col] != 0))
            {
                side = "down";
                col--;
                row++;
            }

            if (side == "down" && (row > n - 1 || matrix[row,col] != 0))
            {
                side = "left";
                col--;
                row--;
            }

            if (side == "left" && (col < 0 || matrix[row,col] != 0))
            {
                side = "up";
                col++;
                row--;
            }

            if (side == "up" && (row < 0 || matrix[row,col] != 0))
            {
                side = "right";
                col++;
                row++;
            }

            matrix[row, col] = i;

            if (side == "right")
            {
                col++;
            }

            if (side == "down")
            {
                row++;
            }

            if (side == "left")
            {
                col--;
            }

            if (side == "up")
            {
                row--;
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i,j]);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}