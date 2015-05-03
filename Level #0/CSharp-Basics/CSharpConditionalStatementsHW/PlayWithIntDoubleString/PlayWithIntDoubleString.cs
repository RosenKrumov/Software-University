using System;

class PlayWithIntDoubleString
{
    static void Main()
    {
        Console.WriteLine("Please choose a type:");
        Console.WriteLine("1 --> int");
        Console.WriteLine("2 --> double");
        Console.WriteLine("3 --> string");
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1: Console.WriteLine("Please enter an int:");
                int num = int.Parse(Console.ReadLine());
                Console.WriteLine(num + 1);
                break;
            case 2: Console.WriteLine("Please enter a double:");
                double d1 = double.Parse(Console.ReadLine());
                Console.WriteLine(d1 + 1);
                break;
            case 3: Console.WriteLine("Please enter a string:");
                string str = Console.ReadLine();
                Console.WriteLine(str + "*");
                break;
            default: Console.WriteLine("Please enter 1, 2 or 3");
                break;
        }
    }
}