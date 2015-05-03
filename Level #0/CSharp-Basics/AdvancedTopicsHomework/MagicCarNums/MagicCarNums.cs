using System;

class MagicCarNums
{
    static void Main()
    {
        int magicWeight = int.Parse(Console.ReadLine());
        int cars = 0;
        char[] letters = { 'A', 'B', 'C', 'E', 'H', 'K', 'M', 'P', 'T', 'X' };
        int weight = 0;

        for (int i = 0; i <= 9; i++)
        {
            for (int j = 0; j <= 9; j++)
            {
                for (int k = 0; k <= 9; k++)
                {
                    for (int l = 0; l <= 9; l++)
                    {
                        for (int m = 0; m <= 9; m++)
                        {
                            for (int n = 0; n <= 9; n++)
                            {
                                weight = 40 + i + j + k + l;
                                switch (letters[m])
                                {
                                    case 'A':
                                        weight += 10;
                                        break;
                                    case 'B':
                                        weight += 20;
                                        break;
                                    case 'C':
                                        weight += 30;
                                        break;
                                    case 'E':
                                        weight += 50;
                                        break;
                                    case 'H':
                                        weight += 80;
                                        break;
                                    case 'K':
                                        weight += 110;
                                        break;
                                    case 'M':
                                        weight += 130;
                                        break;
                                    case 'P':
                                        weight += 160;
                                        break;
                                    case 'T':
                                        weight += 200;
                                        break;
                                    case 'X':
                                        weight += 240;
                                        break;
                                    default:
                                        break;
                                }
                                switch (letters[n])
                                {
                                    case 'A':
                                        weight += 10;
                                        break;
                                    case 'B':
                                        weight += 20;
                                        break;
                                    case 'C':
                                        weight += 30;
                                        break;
                                    case 'E':
                                        weight += 50;
                                        break;
                                    case 'H':
                                        weight += 80;
                                        break;
                                    case 'K':
                                        weight += 110;
                                        break;
                                    case 'M':
                                        weight += 130;
                                        break;
                                    case 'P':
                                        weight += 160;
                                        break;
                                    case 'T':
                                        weight += 200;
                                        break;
                                    case 'X':
                                        weight += 240;
                                        break;
                                    default:
                                        break;
                                }
                                if (weight == magicWeight && ((j == k && k == l) || (i == j && j == k) || (i == j && k == l) || (i == k && j == l) || (i == l && k == j)))
                                {
                                    cars++;
                                }
                            }
                        }
                    }
                }
            }
        }

        Console.WriteLine(cars);
    }
}