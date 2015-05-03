using System;

class BitsUp
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        int index = 0;
        string bits = "";

        for (int i = 0; i < n; i++)
        {
            int bit = int.Parse(Console.ReadLine());
            string bitStr = Convert.ToString(bit, 2).PadLeft(8,'0');
            bits += bitStr;
        }

        char[] bitsCh = bits.ToCharArray();

        for (int i = 0, j = step; i < bits.Length; i++)
        {
            if (i == 1)
            {
                bitsCh[i] = '1';
            }
            if (i == 1 + j)
            {
                bitsCh[i] = '1';
                j += step;
            }
        }

        bits = new string(bitsCh);

        string[] output = new string[bits.Length / 8];

        int ind = 0;

        while (ind < bits.Length)
        {
            output[index] = bits.Substring(ind, 8);
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