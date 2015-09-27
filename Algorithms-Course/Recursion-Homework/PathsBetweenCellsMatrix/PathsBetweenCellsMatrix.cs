namespace PathsBetweenCellsMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PathsBetweenCellsMatrix
    {
        private static int pathsFound = 0;

        static readonly char[,] matrix = 
        {
            {' ', ' ', ' ', ' ', ' ', ' '},
            {' ', '*', '*', ' ', '*', ' '},
            {' ', '*', '*', ' ', '*', ' '},
            {' ', '*', 'e', ' ', ' ', ' '},
            {' ', ' ', ' ', '*', ' ', ' '}
        };

        static readonly List<char> path = new List<char>();

        static bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < matrix.GetLength(0);
            bool colInRange = col >= 0 && col < matrix.GetLength(1);
            return rowInRange && colInRange;
        }

        static void FindPathToExit(int row, int col, char direction)
        {
            if (!InRange(row, col))
            {
                return;
            }

            path.Add(direction);

            if (matrix[row, col] == 'e')
            {
                pathsFound++;
                PrintPath();
            }

            if (matrix[row, col] == ' ')
            {
                matrix[row, col] = 's';

                FindPathToExit(row, col - 1, 'L');
                FindPathToExit(row - 1, col, 'U');
                FindPathToExit(row, col + 1, 'R');
                FindPathToExit(row + 1, col, 'D');

                matrix[row, col] = ' ';
            }

            path.RemoveAt(path.Count - 1);
        }

        private static void PrintPath()
        {
            Console.WriteLine(string.Join("", path.Skip(1)));
        }

        static void Main()
        {
            FindPathToExit(0, 0, 'S');
            Console.WriteLine("Total paths found: {0}", pathsFound);
        }
    }
}
