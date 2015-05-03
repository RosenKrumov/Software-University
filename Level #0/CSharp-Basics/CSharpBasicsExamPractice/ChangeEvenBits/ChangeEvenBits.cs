using System;

class ChangeEvenBits
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int [] numbers = new int[n];
        string[] numbersBinary = new string[n];
        int changedBits = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
            numbersBinary[i] = Convert.ToString(numbers[i], 2);
        }

        int l = int.Parse(Console.ReadLine());
        string lString = Convert.ToString(l, 2);

        for (int i = 0; i < numbersBinary.Length; i++)
        {
            for (int j = 0; j < numbersBinary[i].Length * 2; j+= 2)
            {
                int bit = (l >> j) & 1;
                if (bit == 0)
                {
                    changedBits++;
                }
                l = l | (1 << j);
                
            }
        }

        Console.WriteLine(l);
        Console.WriteLine(changedBits);

    }
}