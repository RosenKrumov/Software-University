using System;

class GravitationOnTheMoon
{
    static void Main()
    {
        int weight = int.Parse(Console.ReadLine());
        Console.WriteLine("Weight on the mooon: {0}", (double) weight*17/100);
    }
}