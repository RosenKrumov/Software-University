using System;

class NullValuesArithmetic
{
    static void Main()
    {
        int? a = null;
        double? b = null;
        Console.WriteLine("This is an integer with null value: " + a);
        Console.WriteLine("This is a double with null value: " + b);
        Console.WriteLine();
        a = 5;
        b = 9.2;
        Console.WriteLine("This is an integer with value 5: " + a);
        Console.WriteLine("This is a double with value 9.2: " + b);
        Console.WriteLine();
    }
}