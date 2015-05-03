using System;
using System.Text.RegularExpressions;

class NineDigitMagicNums
{
    static void Main()
    {
        int sum = int.Parse(Console.ReadLine());
        int diff = int.Parse(Console.ReadLine());
        int a;
        int b;
        int c;

        bool isOK = false;

        for (int i = 555; i < 1000; i++)
        {
            int tempSum = 0;
            a = i;
            b = a + diff;
            c = b + diff;
            string num = a.ToString() + b.ToString() + c.ToString();

            Regex r = new Regex("0|1|2|3|4");
            if (!r.IsMatch(num))
            {
                for (int j = 0; j < num.Length; j++)
                {
                    tempSum += int.Parse(num[j].ToString());

                }
                if (tempSum == sum && num.Length == 9)
                {
                    Console.WriteLine(num);
                    isOK = true;
                }
            }
        }
        if (!isOK)
        {
            Console.WriteLine("No");
        }
    }
}