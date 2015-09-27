namespace EightQueensPuzzle
{
    using System;

    public class EightQueens
    {
        private const int Size = 8;
        static int solutionsFound;
        static readonly bool [,] chessBoard = new bool[Size, Size];
        
        static readonly bool[] attackedCols = new bool[Size]; 
        static readonly bool[] attackedLeftDiagonals = new bool[Size * 2 - 1]; 
        static readonly bool[] attackedRightDiagonals = new bool[Size * 2 - 1];

        static void Main()
        {
            Console.SetBufferSize(200, 1000);
            PutQueens(0);
            Console.WriteLine(solutionsFound);
        }

        static void PutQueens(int row)
        {
            if (row == Size)
            {
                PrintSolution();
            }
            else
            {
                for (int col = 0; col < Size; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkAllAttackedPositions(row, col);
                        PutQueens(row + 1);
                        UnmarkAllAttackedPositions(row, col);
                    }
                }
            }
        }

        private static void UnmarkAllAttackedPositions(int row, int col)
        {
            int index = 0;
            index = GetIndexLeftDiag(row, col, index);
            attackedCols[col] = false;
            attackedLeftDiagonals[index] = false;
            attackedRightDiagonals[row + col] = false;
            chessBoard[row, col] = false;
        }

        private static int GetIndexLeftDiag(int row, int col, int index)
        {
            if (col - row < 0)
            {
                index = Math.Abs(col - row) + Size - 1;
            }
            else if (col - row > 0)
            {
                index = col - row;
            }
            return index;
        }

        private static void MarkAllAttackedPositions(int row, int col)
        {
            int index = 0;
            index = GetIndexLeftDiag(row, col, index);
            attackedCols[col] = true;
            attackedLeftDiagonals[index] = true;
            attackedRightDiagonals[row + col] = true;
            chessBoard[row, col] = true;
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            int index = 0;
            index = GetIndexLeftDiag(row, col, index);
            var ocupiedPositions =
                attackedCols[col] ||
                attackedLeftDiagonals[index] ||
                attackedRightDiagonals[row + col];

            return !ocupiedPositions;
        }

        private static void PrintSolution()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    Console.Write(chessBoard[row, col] ? 'Q' : '-');
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            solutionsFound++;
        }
    }
}
