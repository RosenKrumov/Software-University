using System;

class ExchangeBits
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int p3 = 3;
        int p4 = 4;
        int p5 = 5;
        int p24 = 24;
        int p25 = 25;
        int p26 = 26;
        int bit3, bit4, bit5, bit24, bit25, bit26;

        int nRightP3 = n >> p3;
        bit3 = nRightP3 & 1;
        int nRightP4 = n >> p4;
        bit4 = nRightP4 & 1;
        int nRightP5 = n >> p5;
        bit5 = nRightP5 & 1;
        int nRightP24 = n >> p24;
        bit24 = nRightP24 & 1;
        int nRightP25 = n >> p25;
        bit25 = nRightP25 & 1;
        int nRightP26 = n >> p26;
        bit26 = nRightP26 & 1;


        if (bit24 == 1)
        {
            int mask = 1 << p3;
            n = n | mask;
        }

        else
        {
            int mask = ~(1 << p3);
            n = n & mask;
        }

        if (bit25 == 1)
        {
            int mask = 1 << p4;
            n = n | mask;
        }

        else
        {
            int mask = ~(1 << p4);
            n = n & mask;
        }

        if (bit26 == 1)
        {
            int mask = 1 << p5;
            n = n | mask;
        }

        else
        {
            int mask = ~(1 << p5);
            n = n & mask;
        }
        if (bit3 == 1)
        {
            int mask = 1 << p24;
            n = n | mask;
        }

        else
        {
            int mask = ~(1 << p24);
            n = n & mask;
        }

        if (bit4 == 1)
        {
            int mask = 1 << p25;
            n = n | mask;
        }

        else
        {
            int mask = ~(1 << p25);
            n = n & mask;
        }

        if (bit5 == 1)
        {
            int mask = 1 << p26;
            n = n | mask;
        }

        else
        {
            int mask = ~(1 << p26);
            n = n & mask;
        }

        Console.WriteLine(n);
    }
}