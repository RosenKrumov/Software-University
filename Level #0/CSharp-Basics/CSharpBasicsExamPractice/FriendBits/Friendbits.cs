using System;

class FriendBits
{
    static void Main()
    {
        string n = Console.ReadLine();
        string nString = Convert.ToString(Convert.ToUInt32(n, 10), 2);
        string friendBits = "";
        string aloneBits = "";
        char[] nStringCh = nString.ToCharArray();

        for (int i = 0; i < nStringCh.Length - 1;)
        {
            if (nStringCh[i] == nStringCh[i + 1])
            {
                    while (nStringCh[i] == nStringCh[i + 1] || nStringCh[i] == nStringCh[i - 1])
                    {
                        friendBits += nStringCh[i];
                        i++;
                        if (i == nStringCh.Length - 1)
                        {
                            if (nStringCh[i] == nStringCh[i - 1])
                            {
                                friendBits += nStringCh[i];
                            }
                            else
                            {
                                aloneBits += nStringCh[i];
                            }
                            i++;
                            break;
                        }
                    }
                }

               else
               {
                    aloneBits += nStringCh[i];
                    i++;
                    if (i == nStringCh.Length - 1)
                    {
                        aloneBits += nStringCh[i];
                    }
               }
         }

        if (friendBits == string.Empty)
        {
            friendBits += "0";
        }
        if (aloneBits == string.Empty)
        {
            aloneBits += "0";
        }
        uint friendBitsInt = Convert.ToUInt32(friendBits, 2);
        uint aloneBitsInt = Convert.ToUInt32(aloneBits, 2);
        Console.WriteLine(friendBitsInt);
        Console.WriteLine(aloneBitsInt);

    }
}