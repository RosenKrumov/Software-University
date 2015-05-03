using System;
using System.Collections.Generic;
using System.Linq;

class CountOfNames
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        List<string> names = input.OfType<string>().ToList();
        names.Sort();

        int count = 0;

        for (int i = 0; i < names.Count; )
        {

            while (i < names.Count - 1 && names[i] == names[i + 1])
            {
                count++;
                i++;
            }

            if (i == names.Count - 1)
            {
                if (names[i] == names[i - 1])
                {
                    count++;
                    Console.WriteLine("{0} -> {1}", names[i], count);
                }
                else
                {
                    Console.WriteLine("{0} -> 1", names[i]);
                }
                return;
            }

            if (i > 0 && names[i] == names[i - 1])
            {
                count++;
            }

            else if (i > 0 && i < names.Count - 1 && names[i] != names[i - 1] && names[i] != names[i + 1])
            {
                Console.WriteLine("{0} -> 1", names[i]);
                count = 0;
                i++;
                continue;
            }

            else if (i == 0 && names[i] != names[i + 1])
            {
                Console.WriteLine("{0} -> 1", names[i]);
                count = 0;
                i++;
                continue;
            }

            Console.WriteLine("{0} -> {1}", names[i], count);
            count = 0;
            i++;
        }
    }
}