using System;

class ChessQueens
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());
        int matchings = 0;
        char a = 'a';
        char end = (char)(a + n);
        for (char i = 'a'; i < end; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                for (char k = 'a'; k < end; k++)
                {
                    for (int g = 1; g <= n; g++)
                    {
                        //for (int m = 1; m < n; m++)
                        {
                            if ((k == i + d + 1) && (g == j + d + 1))
                            {
                                Console.WriteLine("{0}{1} - {2}{3}", i, j, k, g);
                                matchings++;
                            }
                            else if (i == k && g == j - d - 1)
                            {
                                Console.WriteLine("{0}{1} - {2}{3}", i, j, k, g);
                                matchings++;
                            }
                            else if (j == g && k == i - 1 - d)
                            {
                                Console.WriteLine("{0}{1} - {2}{3}", i, j, k, g);
                                matchings++;
                            }
                            else if (k == i - d - 1 && j == g - d - 1)
                            {
                                Console.WriteLine("{0}{1} - {2}{3}", i, j, k, g);
                                matchings++;
                            }
                            else if (k == i - d - 1 && g == j - d - 1)
                            {
                                Console.WriteLine("{0}{1} - {2}{3}", i, j, k, g);
                                matchings++;
                            }
                            else if (i == k - 1 - d && j == g - d - 1)
                            {
                                Console.WriteLine("{0}{1} - {2}{3}", i, j, k, g);
                                matchings++;
                            }
                            else if (i == k - d - 1 && g == j - d - 1)
                            {
                                Console.WriteLine("{0}{1} - {2}{3}", i, j, k, g);
                                matchings++;
                            }
                            else if (k == i + d + 1 && g == j)
                            {
                                Console.WriteLine("{0}{1} - {2}{3}", i, j, k, g);
                                matchings++;
                            }
                            else if (g == j + d + 1 && i == k)
                            {
                                Console.WriteLine("{0}{1} - {2}{3}", i, j, k, g);
                                matchings++;
                            }
                            else
                            {
                                continue;
                            }
                        }

                    }
                }
            }
        }
        if (matchings == 0)
        {
            Console.WriteLine("No valid positions");
        }
    }
}
