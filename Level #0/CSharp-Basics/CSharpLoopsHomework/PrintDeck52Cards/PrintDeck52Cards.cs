using System;

class PrintDeck52Cards
{
    static void Main()
    {
        for (int i = 0; i < 13; i++)
        {
                switch (i)
                {
                    case 0:
                        Console.WriteLine("{0}\x05 {0}\x04 {0}\x03 {0}\x06", 2);
                        break;
                    case 1:
                        Console.WriteLine("{0}\x05 {0}\x04 {0}\x03 {0}\x06", 3);
                        break;
                    case 2:
                        Console.WriteLine("{0}\x05 {0}\x04 {0}\x03 {0}\x06", 4);
                        break;
                    case 3:
                        Console.WriteLine("{0}\x05 {0}\x04 {0}\x03 {0}\x06", 5);
                        break;
                    case 4:
                        Console.WriteLine("{0}\x05 {0}\x04 {0}\x03 {0}\x06", 6);
                        break;
                    case 5:
                        Console.WriteLine("{0}\x05 {0}\x04 {0}\x03 {0}\x06", 7);
                        break;
                    case 6:
                        Console.WriteLine("{0}\x05 {0}\x04 {0}\x03 {0}\x06", 8);
                        break;
                    case 7:
                        Console.WriteLine("{0}\x05 {0}\x04 {0}\x03 {0}\x06", 9);
                        break;
                    case 8:
                        Console.WriteLine("{0}\x05 {0}\x04 {0}\x03 {0}\x06", 10);
                        break;
                    case 9:
                        Console.WriteLine("J\x05 J\x04 J\x03 J\x06");
                        break;
                    case 10:
                        Console.WriteLine("Q\x05 Q\x04 Q\x03 Q\x06");
                        break;
                    case 11:
                        Console.WriteLine("K\x05 K\x04 K\x03 K\x06");
                        break;
                    case 12:
                        Console.WriteLine("A\x05 A\x04 A\x03 A\x06");
                        break;
                }
        }
    }
}