using System;

class LongestWordInText
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] inputStr = input.Split(' ');
        string longestWord = "";

        for (int i = 0; i < inputStr.Length; i++)
        {
            if (longestWord.Length < inputStr[i].Length)
            {
                longestWord = inputStr[i];
            }
        }

        Console.WriteLine(longestWord);
    }
}