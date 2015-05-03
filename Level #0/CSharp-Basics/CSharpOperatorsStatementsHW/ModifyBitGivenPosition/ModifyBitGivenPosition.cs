using System;

class ModifyBitGivenPosition
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());
        int v = int.Parse(Console.ReadLine());
        if (v != 1 && v != 0)
        {
            Console.WriteLine("v must be 1 or 0");
        }
        else
        {
            if (v == 1)
            {
                int mask = 1 << p;
                int result = n | mask;
                Console.WriteLine(result);
            }

            else
            {
                int mask = ~(1 << p);
                int result = n & mask;
                Console.WriteLine(result);
            }
        }
    }
}