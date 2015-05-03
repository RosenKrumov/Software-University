using System;

class BitsExchangeAdvanced_vol02
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());
        int q = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        char[] bits = Convert.ToString(n, 2).ToCharArray();

        char[] bitsToExchange = new char[k * 2];

        int pos = 0;
        for (int i = bits.Length - 1 - p; i > bits.Length - 1 - p - k; i--)
        {
            bitsToExchange[pos] = bits[i];
            pos++;
        }

        pos = k;
        for (int i = bits.Length - 1 - q; i > bits.Length - 1 - q - k; i--)
        {
            bitsToExchange[pos] = bits[i];
            pos++;
        }

        for (int i = 0; i < k; i++)
        {
            bits[q + i] = bitsToExchange[i];
        }

        for (int i = 0; i < k; i++)
        {
            bits[p + i] = bitsToExchange[i + k];
        }


        int output = Convert.ToInt32(new string(bits), 2);

        Console.WriteLine(output);
    }
}

