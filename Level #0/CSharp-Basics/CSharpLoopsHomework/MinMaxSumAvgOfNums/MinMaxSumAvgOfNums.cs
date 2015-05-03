using System;
using System.Linq;

class MinMaxSumAvgOfNums
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        double[] input = new double[n];
        double sum = 0;
        for (int i = 0; i < n; i++)
        {
            input[i] = double.Parse(Console.ReadLine());
            sum += input[i];
        }
        Console.WriteLine("min = {0:F2}", input.Min().ToString("0.##"));
        Console.WriteLine("max = {0:F2}", input.Max().ToString("0.##"));
        Console.WriteLine("sum = {0:F2}", sum.ToString("0.##"));
        Console.WriteLine("avg = {0:F2}", input.Average().ToString("0.##"));
    }
}