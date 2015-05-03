using System;

class DecToHex
{
    static void Main(string[] args)
    {
        long input = long.Parse(Console.ReadLine());
        string inputStr = "";
        long remainder = 0;
        string result = "";

        for (long i = input; i > 0; i/=16)
        {
            remainder = i % 16;
            switch (remainder)
            {
                case 10: inputStr += 'A'; break;
                case 11: inputStr += 'B'; break;
                case 12: inputStr += 'C'; break;
                case 13: inputStr += 'D'; break;
                case 14: inputStr += 'E'; break;
                case 15: inputStr += 'F'; break;
                default: inputStr = inputStr + remainder; break;
            }
        }

        for (int i = inputStr.Length - 1; i >= 0; i--)
        {
            result += inputStr[i].ToString();
        }
        Console.WriteLine(result);
    }
}