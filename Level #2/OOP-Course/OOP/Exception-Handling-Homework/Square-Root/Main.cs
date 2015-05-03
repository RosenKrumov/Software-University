using System;

class SquareRoot
{
    static void Main()
    {
        try
        {
            uint num = uint.Parse(Console.ReadLine());
            double root = Math.Sqrt(num);
            Console.WriteLine(root);

        }
        catch (OverflowException oEx) 
        {
            Console.WriteLine("Invalid number");
            Console.WriteLine(oEx.Message);
        }
        catch (FormatException fEx)
        {
            Console.WriteLine("Invalid number");
            Console.WriteLine(fEx.Message);
        }
        finally
        {
            Console.WriteLine("Good bye");
        }
    }
}