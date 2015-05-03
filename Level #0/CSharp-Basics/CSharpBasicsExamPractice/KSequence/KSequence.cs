using System;

class KSequence
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        int equalsSum = 0;
        string lastNum = input[0];
        bool print = false;

        for (int i = 0; i < input.Length; i++)
        {
            input[i].Replace(" ", string.Empty);
        }

        int k = int.Parse(Console.ReadLine());
        int count = 1;
        int numOfElements = 0;
        for (int i = 1; i < input.Length; i++)
        {
            if (lastNum == input[i])
            {
                count++;
            }

            else
            {
                numOfElements = count;
                if (count >= k)
                {
                    numOfElements = count % k;
                    
                }
                count = 1;
                for (int j = 0; j < numOfElements; j++)
                {
                    if (print == false)
                    {
                        Console.Write(lastNum + " ");
                    }

                    else
                    {
                        Console.Write(lastNum);
                    }
                    
                }
            }

            lastNum = input[i];
        }

        numOfElements = count;
        if (count >= k)
        {
            numOfElements = count % k;

        }
        count = 1;
        for (int j = 0; j < numOfElements; j++)
        {
            if (print == false)
            {
                Console.Write(lastNum + " ");
            }

            else
            {
                Console.Write(lastNum);
            }

        }
        Console.WriteLine();

    }
}