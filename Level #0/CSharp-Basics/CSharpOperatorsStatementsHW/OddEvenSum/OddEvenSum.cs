using System;

class HalfSum
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());
        int n = 2 * count;
        int[] numbers = new int[n];
        int sum1 = 0;
        int sum2 = 0;
        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < n; i=i+2)
        {
            sum1 = sum1 + numbers[i];
        }
        for (int i = 1; i <= n; i=i+2)
        {
            sum2 = sum2 + numbers[i];
        }
        if (sum1 == sum2)
        {
            Console.WriteLine("Yes, sum={0}", sum1);
        }
        else
        {
            Console.WriteLine("No, diff={0}", Math.Abs(sum1 - sum2));
        }
    }
}