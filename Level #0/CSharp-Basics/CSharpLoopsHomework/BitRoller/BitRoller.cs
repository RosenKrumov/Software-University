using System;

class BitRoller
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int f = int.Parse(Console.ReadLine());
        int r = int.Parse(Console.ReadLine());
        
        string binary = Convert.ToString(n, 2).PadLeft(19, '0');
        char frozenBit = binary[binary.Length - f - 1];
        int index = binary.Length - f - 1;

        for (int i = 0; i < r; i++)
        {
            if (f != 0)
            {
                char bit = binary[binary.Length - 1];
                binary = binary.Remove(binary.Length - 1);
                binary = binary.PadLeft(19, bit);
                char[] binaryCh = binary.ToCharArray();
                char previousBit = binaryCh[index];
                binaryCh[index] = frozenBit;
                binaryCh[index + 1] = previousBit;
                binary = new string(binaryCh);                    
            }

            else
            {
                char bit = binary[binary.Length - 2];
                binary = binary.Remove(binary.Length - 2, 1);
                binary = binary.PadLeft(19, bit);
                char[] binaryCh = binary.ToCharArray();
                binaryCh[binary.Length - 1 - f] = frozenBit;
                binary = new string(binaryCh);
            }

        }

        int binaryInt = Convert.ToInt32(binary, 2);
        Console.WriteLine(binaryInt);
    }
}