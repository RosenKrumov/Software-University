using System;

class DrawFigure
{
    static void Main()
    {
        int height = int.Parse(Console.ReadLine());
        Console.WriteLine(new string('*', height));
        for (int i = 2; i <= height/2; i++)
        {
            Console.Write(new string('.', i - 1));
            Console.Write(new string('*', height - 2*i + 2));
            Console.WriteLine(new string('.', i - 1));
        } 

        Console.Write(new string('.', height/2));
        Console.Write("*");
        Console.WriteLine(new string('.', height/2));

        for (int i = height/2 + 1; i <= height - 1; i++)
        {
            Console.Write(new string('.', height - i - 1 ));
            Console.Write(new string('*', 2*i - height + 2 ));
            Console.WriteLine(new string('.', height - i - 1 ));
        }

        
    }
}
