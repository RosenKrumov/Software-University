using System;
class CatchTheBits
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        string bits = "";
        int index = 0;

        for (int i = 0; i < n; i++)
        {
            int bit = int.Parse(Console.ReadLine());
            string bitStr = Convert.ToString(bit, 2).PadLeft(8, '0');
            bits += bitStr;
        }

        char[] bitsCh = bits.ToCharArray();
        string extractedBits = "";

        for (int i = 0, j = step; i < bits.Length; i++)
        {
            if (i == 1)
            {
                extractedBits += bitsCh[i];
            }
            if (i == 1 + j)
            {
                extractedBits += bitsCh[i];
                j += step;
            }
        }

        while (extractedBits.Length % 8 != 0)
        {
            extractedBits += "0";
        }

        string[] output = new string[extractedBits.Length / 8];

        int ind = 0;

        while (ind < extractedBits.Length)
        {
            output[index] = extractedBits.Substring(ind, 8);
            ind += 8;
            index++;
        }

        for (int i = 0; i < output.Length; i++)
        {
            output[i] = Convert.ToInt32(output[i], 2).ToString();
            Console.WriteLine(output[i]);
        }
    }
}