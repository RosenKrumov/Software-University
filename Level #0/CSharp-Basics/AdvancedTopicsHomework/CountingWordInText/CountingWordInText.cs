using System;
using System.IO;
class CountingWordInText
{
    static void Main()
    {
        string word = Console.ReadLine();
        Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));
        string text = Console.ReadLine();
        string[] wordStr = text.Split(new char[] { ' ', '.', ',', '"', '@', '!', '?', '/', '\\', ':', ';', '(', ')', '%', '_', '+', '-' }, StringSplitOptions.None);
        int count = 0;

        for (int i = 0; i < wordStr.Length; i++)
        {
            if (string.Equals(wordStr[i], word, StringComparison.OrdinalIgnoreCase))
            {
                count++;
            }            
        }

        Console.WriteLine(count);
    }
}