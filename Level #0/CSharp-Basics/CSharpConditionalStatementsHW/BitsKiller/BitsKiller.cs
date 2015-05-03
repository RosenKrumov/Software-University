using System;

class BitsKiller
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

        string output = "";

        for (int i = 0, j = step; i < bits.Length; i++)
        {
            if (i == 1)
            {
                continue;
            }
            
            else if (i == 1 + j)
            {
                j += step;
                continue;
            }

            else
            {
                output += bits[i].ToString();
            }
        }

        while (output.Length % 8 != 0)
        {
            output += "0";
        }

        string[] outputFull = new string[output.Length / 8];

        int ind = 0;

        while (ind < output.Length)
        {
            outputFull[index] = output.Substring(ind, 8);
            ind += 8;
            index++;
        }

        for (int i = 0; i < outputFull.Length; i++)
        {
            outputFull[i] = Convert.ToInt32(outputFull[i], 2).ToString();
            Console.WriteLine(outputFull[i]);
        }


    }
}