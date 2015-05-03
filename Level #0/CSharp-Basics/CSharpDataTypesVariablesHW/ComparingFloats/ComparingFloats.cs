using System;

class ComparingFloats
{
    static void Main()
    {
        Console.Write("Type in first number: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Type in second number: ");
        double b = double.Parse(Console.ReadLine());
        double difference = Math.Abs(a - b);
        double eps = 0.000001;
        if(difference >= eps)
        {
            Console.WriteLine("Not equal");
        }
        else
        {
            Console.WriteLine("Equal");
        }
    }
}