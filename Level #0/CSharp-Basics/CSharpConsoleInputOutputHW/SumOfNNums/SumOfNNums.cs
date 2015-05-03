using System;

class SumOfNNums
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        double sum = 0;
        for (int i = 0; i < n; i++)
        {
            double nums = double.Parse(Console.ReadLine());
            sum += nums;
        }
        Console.WriteLine(sum);
    }
}