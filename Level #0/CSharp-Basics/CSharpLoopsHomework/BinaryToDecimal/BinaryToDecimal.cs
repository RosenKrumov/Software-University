using System;

    class BinaryToDecimal
    {
        static void Main()
        {
            string input = Console.ReadLine();
            long sum = 0;

            for (int i = input.Length - 1, j = 0; i >= 0; i--, j++)
            {
                sum += Convert.ToInt32(input[i].ToString()) * (long)Math.Pow(2, j);
            }

            Console.WriteLine(sum);
        }
    }