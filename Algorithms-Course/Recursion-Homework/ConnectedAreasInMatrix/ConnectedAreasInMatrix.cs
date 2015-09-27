namespace ConnectedAreasInMatrix
{
    using System;
    using System.Collections.Generic;

    public class ConnectedAreasInMatrix
    {
        static readonly char[,] matrix = 
        {
            {' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' '},
            {' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' '},
            {' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' '},
            {' ', ' ', ' ', ' ', '*', ' ', '*', ' ', ' '}
        };

        //static readonly char[,] matrix = 
        //{
        //    {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
        //    {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
        //    {'*', ' ', ' ', '*', '*', '*', '*', '*', ' ', ' '},
        //    {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
        //    {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
        //};

        static readonly SortedSet<ConnectedArea> areas = new SortedSet<ConnectedArea>();

        public static void Main()
        {
            do
            {
                var point = FindConnectedArea();
                
                var connectedArea = new ConnectedArea()
                {
                    Start = point
                };

                FindConnectedCells(point.X, point.Y, connectedArea);

                areas.Add(connectedArea);
            } while (FindConnectedArea() != null);

            Print();
        }

        private static void Print()
        {
            Console.WriteLine("Total areas found: {0}", areas.Count);
            var id = 1;
            foreach (var connectedArea in areas)
            {
                Console.WriteLine("Area #{0} at ({1}, {2}), size: {3}", id, connectedArea.Start.X, connectedArea.Start.Y, connectedArea.Size);
                id++;
            }
        }

        private static void FindConnectedCells(int x, int y, ConnectedArea connectedArea)
        {
            if (!InRange(x, y))
            {
                return;
            }

            if (matrix[x, y] == 'x')
            {
                return;
            }

            if (matrix[x, y] == '*')
            {
                return;
            }

            connectedArea.Size++;
            matrix[x, y] = 'x';

            FindConnectedCells(x - 1, y, connectedArea); //Up
            FindConnectedCells(x, y - 1, connectedArea); //Left
            FindConnectedCells(x + 1, y, connectedArea); //Down
            FindConnectedCells(x, y + 1, connectedArea); //Right
        }

        private static Point FindConnectedArea()
        {
            var point = new Point();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == ' ')
                    {
                        point.X = row;
                        point.Y = col;
                        return point;
                    }
                }
            }

            return null;
        }

        private static bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < matrix.GetLength(0);
            bool colInRange = col >= 0 && col < matrix.GetLength(1);
            return rowInRange && colInRange;
        }
    }
}