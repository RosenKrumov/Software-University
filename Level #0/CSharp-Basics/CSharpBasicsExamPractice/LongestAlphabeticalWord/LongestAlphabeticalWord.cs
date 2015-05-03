using System;

class LongestAlphabeticalWord
{
    static void Main()
    {
        string word = Console.ReadLine();
        int n = int.Parse(Console.ReadLine());
        char[,] field = new char[n, n];
        int index = 0;
        string alphabeticalWord = "";

        for (int row = 0; row < 7; row++)
        {
            for (int col = 0; col < 7; col++)
            {
                if (index == word.Length)
                {
                    index = 0;
                }
                field[row, col] = word[index];
                index++;
                if (index == word.Length - 1 && n > word.Length - 1)
                {
                    index = 0;
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                
            }
        }
    }
}