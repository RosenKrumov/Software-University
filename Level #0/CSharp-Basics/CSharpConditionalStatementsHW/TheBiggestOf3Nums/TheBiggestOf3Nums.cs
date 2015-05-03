using System;

class TheBiggestOf3Nums
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        double maxAB = Math.Max(a, b);
        Console.WriteLine(Math.Max(maxAB,c));
        
    }
}