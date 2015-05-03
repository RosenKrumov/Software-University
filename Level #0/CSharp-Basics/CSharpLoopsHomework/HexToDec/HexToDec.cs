using System;

class HexToDec
{
    static void Main()
    {
        string input = Console.ReadLine();
        int[] inputInt = new int[input.Length];

        for (int i = input.Length - 1; i >= 0; i--)
        {
            switch (input[i])
            {
                case '0': inputInt[i] = 0; break;
                case '1': inputInt[i] = 1; break;
                case '2': inputInt[i] = 2; break;
                case '3': inputInt[i] = 3; break;
                case '4': inputInt[i] = 4; break;
                case '5': inputInt[i] = 5; break;
                case '6': inputInt[i] = 6; break;
                case '7': inputInt[i] = 7; break;
                case '8': inputInt[i] = 8; break;
                case '9': inputInt[i] = 9; break;
                case 'A': inputInt[i] = 10; break;
                case 'B': inputInt[i] = 11; break;
                case 'C': inputInt[i] = 12; break;
                case 'D': inputInt[i] = 13; break;
                case 'E': inputInt[i] = 14; break;
                case 'F': inputInt[i] = 15; break;
                default: break;
            }            
        }
        double output = 0.0d;
        for (int i = inputInt.Length - 1, j = 0; i >= 0; i--, j++)
		{
            output += (double)inputInt[i] * Math.Pow((double)16, j);

		}
        Console.WriteLine(output);
    }
}