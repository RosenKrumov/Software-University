using System;

class CalculateExpression
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int x = int.Parse(Console.ReadLine());
        double sum = 1;
        int factorial = 1;
        for (int i = 1, j = 1; j <= n; i++, j++)
        {
            factorial *= i;
            sum += factorial / Math.Pow(x, j);
        }
        Console.WriteLine("{0:F5}", sum);
    }
}