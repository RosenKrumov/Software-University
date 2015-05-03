using System;
using System.Collections.Generic;
using System.Linq;

class JoinLists
{
    static void Main()
    {
        string[] inputFirst = Console.ReadLine().Split(' ');
        int[] inputFirstInt = new int[inputFirst.Length];
        for (int i = 0; i < inputFirst.Length; i++)
        {
            inputFirstInt[i] = Convert.ToInt32(inputFirst[i]);
        }
        List<int> inputFirstList = inputFirstInt.OfType<int>().ToList();

        string[] inputSec = Console.ReadLine().Split(' ');
        int[] inputSecInt = new int[inputSec.Length];
        for (int i = 0; i < inputSec.Length; i++)
        {
            inputSecInt[i] = Convert.ToInt32(inputSec[i]);
        }
        List<int> inputSecList = inputSecInt.OfType<int>().ToList();

        List<int> output = inputFirstList.Union(inputSecList).ToList();
        output.Sort();

        foreach (var number in output)
        {
            Console.Write(number + " ");
        }
    }
}