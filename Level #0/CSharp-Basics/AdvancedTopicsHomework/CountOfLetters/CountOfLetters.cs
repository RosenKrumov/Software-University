using System;
using System.Collections.Generic;
using System.Linq;

class CountOfLetters
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        List<string> letters = input.OfType<string>().ToList();
        letters.Sort();
        int count = 0;

        for (int i = 0; i < letters.Count - 1; )
        {
            
            while (i < letters.Count - 1 && letters[i] == letters[i + 1])
            {
                count++;
                i++;
            }

            if (i == letters.Count - 1)
            {
                if (letters[i] == letters[i - 1])
                {
                    count++;
                    Console.WriteLine("{0} -> {1}", letters[i], count);
                }
                else
                {
                    Console.WriteLine("{0} -> {1}", letters[i], count);
                }
                return;
            }

            if (i > 0 && letters[i] == letters[i - 1])
            {
                count++;
                
            }
            else if (i > 0 && i < letters.Count - 1 && letters[i] != letters [i - 1] && letters[i] != letters[i + 1])
            {
                Console.WriteLine("{0} -> 1", letters[i]);
                count = 0;
                i++;
                continue;
            }

            Console.WriteLine("{0} -> {1}", letters[i], count);
            count = 0;
            i++;
        }

    }
}