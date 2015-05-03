using System;

class DecimalToBinary
{
    static void Main()
    {
        long input = long.Parse(Console.ReadLine());
        string sum = "";
        string output = "";

        for (long i = input; i > 0; i/=2)
        {
            sum += i % 2;
        }

        for (int i = sum.Length - 1; i >= 0; i--)
        {
            output += sum[i].ToString();
        }

        Console.WriteLine(output);

    }
}