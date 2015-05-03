using System;

class PrintASCIITable
{
    static void Main()
    {
        for (int i = 0; i < 255; i++)
        {
            Console.Write((char)i + " ");
        }
    }
}