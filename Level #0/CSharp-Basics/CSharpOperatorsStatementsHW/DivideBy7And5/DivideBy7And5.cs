using System;

class DivideBy7And5
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        if ((n % 5 == 0) && (n % 7 == 0) && (n != 0))
        {
            Console.WriteLine("True");
        }
        else
        {
            Console.WriteLine("False");
        }
        
    }
}