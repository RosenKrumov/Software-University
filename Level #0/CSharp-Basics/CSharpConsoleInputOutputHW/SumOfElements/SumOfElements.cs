using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        int[] nums = new int[1000];
        long sum = 0;
        for (int i = 0; i < input.Length; i++)
        {
            nums[i] = int.Parse(input[i]);
            
            
        }
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
        }
        sum -= nums.Max();
        if (sum==nums.Max())
        {
            Console.WriteLine("Yes, sum=" + sum);
        }
        else
        {
            Console.WriteLine("No, diff=" + Math.Abs(sum-nums.Max()));
        }

    }
}