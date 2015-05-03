using System;

class BitShooter
{
    static void Main()
    {
        ulong n = ulong.Parse(Console.ReadLine());
        string[] firstShooter = Console.ReadLine().Split(' ');
        int firstShooterCenter = Convert.ToInt32(firstShooter[0]);
        int firstShooterSize = Convert.ToInt32(firstShooter[1]);
        string[] secondShooter = Console.ReadLine().Split(' ');
        int secondShooterCenter = Convert.ToInt32(secondShooter[0]);
        int secondShooterSize = Convert.ToInt32(secondShooter[1]);
        string[] thirdShooter = Console.ReadLine().Split(' ');
        int thirdShooterCenter = Convert.ToInt32(thirdShooter[0]);
        int thirdShooterSize = Convert.ToInt32(thirdShooter[1]);
        byte[] nBit = BitConverter.GetBytes(n);
        string nStr = "";

        for (int i = nBit.Length - 1; i >= 0; i--)
        {
            string nBitStr = Convert.ToString(nBit[i], 2).PadLeft(8, '0');
            nStr += nBitStr;
        }
        char[] nStrCh = nStr.ToCharArray();

        for (int i = 63 - firstShooterCenter, j = 63 - firstShooterCenter; i <= 63 - firstShooterCenter + firstShooterSize / 2; i++, j--)
        {
            if (i <= 63)
            {
                nStrCh[i] = '0';
            }
            if (j >= 0)
            {
                nStrCh[j] = '0';
            }
        }

        for (int i = 63 - secondShooterCenter, j = 63 - secondShooterCenter; i <= 63 - secondShooterCenter + secondShooterSize / 2; i++, j--)
        {
            if (i <= 63)
            {
                nStrCh[i] = '0';
            }
            if (j >= 0)
            {
                nStrCh[j] = '0';
            }
        }

        for (int i = 63 - thirdShooterCenter, j = 63 - thirdShooterCenter; i <= 63 - thirdShooterCenter + thirdShooterSize / 2; i++, j--)
        {
            if (i <= 63)
            {
                nStrCh[i] = '0';
            }
            if (j >= 0)
            {
                nStrCh[j] = '0';
            }
        }

        nStr = new string(nStrCh);
        int onesLeft = 0;
        int onesRight = 0;

        for (int i = 0; i < 32; i++)
        {
            if (nStr[i] == '1')
            {
                onesLeft++;
            }
        }
        for (int i = 32; i < 64; i++)
        {
            if (nStr[i] == '1')
            {
                onesRight++;
            }
        }
        Console.WriteLine("left: {0}", onesLeft);
        Console.WriteLine("right: {0}", onesRight);
    }
}