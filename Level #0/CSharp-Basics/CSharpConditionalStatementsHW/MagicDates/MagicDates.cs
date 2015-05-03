using System;

class MagicDates
{
    static void Main()
    {
        string startYear = Console.ReadLine();
        string endYear = Console.ReadLine();
        int magicWeight = int.Parse(Console.ReadLine());

        DateTime dStart = new DateTime(int.Parse(startYear), 1, 1);
        DateTime dEnd = new DateTime(int.Parse(endYear), 12, 31);

        int count = 0;

        for (DateTime date = dStart; date <= dEnd; date = date.AddDays(1))
        {
            int date1 = date.Day / 10;
            int date2 = date.Day % 10;
            int date3 = date.Month / 10;
            int date4 = date.Month % 10;
            int date5 = date.Year / 1000 % 10;
            int date6 = date.Year / 100 % 10;
            int date7 = date.Year / 10 % 10;
            int date8 = date.Year % 10;

            int sum = 0;

            int[] digits = { date1, date2, date3, date4, date5, date6, date7, date8 };

            for (int i = 0; i < digits.Length; i++)
            {
                for (int j = i + 1; j < digits.Length; j++)
                {
                    sum += digits[i] * digits[j];

                }

            }

            if (sum == magicWeight)
            {
                Console.WriteLine("{0:d2}-{1:d2}-{2}", date.Day, date.Month, date.Year);
                count++;
            }
        }

        if (count == 0)
        {
            Console.WriteLine("No");
        }

    }
}