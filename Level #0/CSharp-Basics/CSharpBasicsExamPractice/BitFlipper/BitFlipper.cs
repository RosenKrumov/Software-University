using System;

class BitFlipper
{
    static void Main()
    {
        ulong n = ulong.Parse(Console.ReadLine());
        byte[] nBit = BitConverter.GetBytes(n);
        string nStr = "";
        for (int i = nBit.Length - 1; i >= 0; i--)
        {
            string nBitStr = Convert.ToString(nBit[i], 2).PadLeft(8, '0');
            nStr += nBitStr;
        }
        
        char[] nStrCh = nStr.ToCharArray();

        for (int i = 0; i <= nStrCh.Length - 3;)
        {
            if (nStrCh[i] == nStrCh [i + 1] && nStrCh[i + 1] == nStrCh[i + 2])
            {
                if (nStrCh[i] == '0')
                {
                    nStrCh[i] = '1';
                    nStrCh[i + 1] = '1';
                    nStrCh[i + 2] = '1';
                    i += 3;
                }

                else 
                {
                    nStrCh[i] = '0';
                    nStrCh[i + 1] = '0';
                    nStrCh[i + 2] = '0';
                    i += 3;
                }
            }
            else
            {
                i++;
            }
            
        }

        nStr = new string(nStrCh);
        ulong output = Convert.ToUInt64(nStr, 2);

        Console.WriteLine(output);
        
    }
}