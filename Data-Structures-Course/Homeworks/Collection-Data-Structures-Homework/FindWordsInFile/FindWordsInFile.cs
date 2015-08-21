using System;
using System.Collections.Generic;
using System.Text;

namespace FindWordsInFile
{
    public class FindWordsInFile
    {
        static void Main()
        {
            var wordsCount = new Dictionary<string, int>();
            var output = new StringBuilder();
            var textLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < textLines; i++)
            {
                var text = Console.ReadLine();
                var words = text.Split(new[] {' ', ',', '.', '?', '!', '/', '\\', ';'},
                    StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    if (!wordsCount.ContainsKey(word))
                    {
                        wordsCount[word] = 0;
                    }

                    wordsCount[word]++;
                }
            }

            var wordLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < wordLines; i++)
            {
                var word = Console.ReadLine().Trim();
                output.AppendLine(string.Format("{0} -> {1}", word, wordsCount[word]));
            }

            Console.Write(output.ToString());
        }
    }
}
