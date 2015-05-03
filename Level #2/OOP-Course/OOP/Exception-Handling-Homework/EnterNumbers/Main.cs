using System;

class ReadNums
{
    static void Main()
    {
        int start = 1;
        int end = 100;
        ReadTenNumbers(start, end);
    }

    static int ReadNumber(int start, int end)
    {
        int number;
        
        try
        {
            Console.WriteLine("Enter a number between {0} and {1}", start, end);
            number = int.Parse(Console.ReadLine());
            if (number < start || number > end)
            {
                while (number < start || number > end)
                {
                    Console.WriteLine("Please enter a number between {0} and {1}", start, end);
                    number = int.Parse(Console.ReadLine());
                    
                }
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number!");
            throw;
        }

        return number;
    }

    static void ReadTenNumbers(int start, int end)
    {
        int[] numArr = new int[10];
        for (int i = 0; i < numArr.Length; i++)
        {
            numArr[i] = ReadNumber(start, end);
            start = numArr[i];
        }
    }
}