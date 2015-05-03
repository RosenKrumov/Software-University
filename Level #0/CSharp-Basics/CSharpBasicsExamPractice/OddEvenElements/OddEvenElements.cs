using System;
using System.Linq;

class OddEvenElements
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        double[] inputInt = new double[input.Length];
        double oddSum = 0.0;
        double evenSum = 0.0;
        double oddMin = 0.0;
        double oddMax = 0.0;
        double evenMin = 0.0;
        double evenMax = 0.0;

        for (int i = 0; i < input.Length; i++)
        {
            inputInt[i] = Convert.ToDouble(input[i].ToString());
        }

        for (int i = 0; i < inputInt.Length; i += 2)
        {
            oddSum += inputInt[i];
        }

        for (int i = 1; i < inputInt.Length; i += 2)
        {
            evenSum += inputInt[i];
        }

        if (inputInt.Length > 0)
        {
            oddMin = inputInt[0];
            oddMax = inputInt[0];
        }


        for (int i = 0; i < inputInt.Length; i += 2)
        {
            if (oddMin > inputInt[i])
            {
                oddMin = inputInt[i];
            }

            if (oddMax < inputInt[i])
            {
                oddMax = inputInt[i];
            }
        }

        if (inputInt.Length > 1)
        {
            evenMin = inputInt[1];
            evenMax = inputInt[1];
        }


        for (int i = 1; i < inputInt.Length; i += 2)
        {
            if (i >= inputInt.Length)
            {
                continue;
            }
            else
            {
                if (evenMin > inputInt[i])
                {
                    evenMin = inputInt[i];
                }

                if (evenMax < inputInt[i])
                {
                    evenMax = inputInt[i];
                }
            }

        }

        if (inputInt.Length == 0 || input.Length == 0)
        {
            Console.WriteLine("OddSum=No, OddMin=No, OddMax=No, EvenSum=No, EvenMin=No, EvenMax=No");
        }
        else if (inputInt.Length == 1)
        {
            Console.WriteLine("OddSum={0}, OddMin={1}, OddMax={2}, EvenSum=No, EvenMin=No, EvenMax=No", oddSum, oddMin, oddMax);
        }
        else
        {
            Console.WriteLine("OddSum={0}, OddMin={1}, OddMax={2}, EvenSum={3}, EvenMin={4}, EvenMax={5}", oddSum.ToString("0.####"), oddMin.ToString("0.####"), oddMax.ToString("0.####"),
                evenSum.ToString("0.####"), evenMin.ToString("0.####"), evenMax.ToString("0.####"));
        }
    }
}