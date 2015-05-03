using System;
using System.Collections.Generic;
using System.Linq;

class RemoveNames
{
    static void Main()
    {
        string[] inputFirst = Console.ReadLine().Split(' ');
        List<string> inputFirstList = inputFirst.OfType<string>().ToList();
        string[] inputSec = Console.ReadLine().Split(' ');
        List<string> inputSecList = inputSec.OfType<string>().ToList();

        for (int i = 0; i < inputSecList.Count; i++)
        {
            for (int j = 1; j < inputFirstList.Count; j++)
            {
                if (inputSecList[i] == inputFirstList[j])
                {
                    inputFirstList.RemoveAt(j);
                }
                else if (inputSecList[i] == inputFirstList[j - 1])
                {
                    inputFirstList.RemoveAt(j - 1);
                }
            }
        }

        for (int i = 0; i < inputFirstList.Count; i++)
        {
            Console.Write(inputFirstList[i] + " ");
        }

        Console.WriteLine();
    }
}