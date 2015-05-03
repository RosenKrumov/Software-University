using System;

class DoubleDowns
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] bits = new int[n];
        int rightDiagonal = 0;
        int leftDiagonal = 0;
        int vertical = 0;

        for (int i = 0; i < bits.Length; i++)
        {
            bits[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < n - 1; i++)
        {
            string bit1 = Convert.ToString(bits[i], 2);
            bit1 = bit1.PadLeft(32, '0');
            string bit2 = Convert.ToString(bits[i + 1], 2);
            bit2 = bit2.PadLeft(32, '0');

            for (int j = 0; j < bit1.Length; j++)
            {
                if (j == 0)
                {
                    for (int k = j; k < j + 2; k++)
                    {
                        if (bit1[j] == '1' && bit1[j] == bit2[k])
                        {
                            if (k == j)
                            {
                                vertical++;
                                continue;
                            }
                            else if (k == j + 1)
                            {
                                rightDiagonal++;
                                continue;
                            }
                        }
                    }
                }

                else if (j > 0 && j < 31)
                {
                    for (int k = j - 1; k < j + 2; k++)
                    {
                        if (bit1[j] == '1' && bit1[j] == bit2[k])
                        {
                            if (k == j - 1)
                            {
                                leftDiagonal++;
                                continue;
                            }
                            else if (k == j)
                            {
                                vertical++;
                                continue;                                
                            }
                            else if (k == j + 1)
                            {
                                rightDiagonal++;
                                continue;
                            }

                        }
                       
                    }
                }
                else if (j == 31)
                {
                    for (int k = j - 1; k < j + 1; k++)
                    {
                        if (bit1[j] == '1' && bit1[j] == bit2[k])
                        {
                            if (k == j - 1)
                            {
                                leftDiagonal++;
                                continue;
                            }
                            else if (k == j)
                            {
                                vertical++;
                                continue;                                
                            }

                        }
                        
                    }
                }
            }
        }
        Console.WriteLine(rightDiagonal);
        Console.WriteLine(leftDiagonal);
        Console.WriteLine(vertical);
    }
}
