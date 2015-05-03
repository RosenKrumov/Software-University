using System;

class MagicStrings
{
    static void Main()
    {
        int diff = int.Parse(Console.ReadLine());
        char[] letters = { 'k', 'n', 'p', 's' };
        int weightFirst = 0;
        int weightSecond = 0;
        int matchings = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                for (int k = 0; k < 4; k++)
                {
                    for (int l = 0; l < 4; l++)
                    {
                        for (int m = 0; m < 4; m++)
                        {
                            for (int n = 0; n < 4; n++)
                            {
                                for (int p = 0; p < 4; p++)
                                {
                                    for (int q = 0; q < 4; q++)
                                    {
                                        switch (letters[i])
                                        {
                                            case 's':
                                                weightFirst += 3;
                                                break;
                                            case 'n':
                                                weightFirst += 4;
                                                break;
                                            case 'k':
                                                weightFirst += 1;
                                                break;
                                            case 'p':
                                                weightFirst += 5;
                                                break;
                                            default:
                                                break;
                                        }
                                        switch (letters[j])
                                        {
                                            case 's':
                                                weightFirst += 3;
                                                break;
                                            case 'n':
                                                weightFirst += 4;
                                                break;
                                            case 'k':
                                                weightFirst += 1;
                                                break;
                                            case 'p':
                                                weightFirst += 5;
                                                break;
                                            default:
                                                break;
                                        }
                                        switch (letters[k])
                                        {
                                            case 's':
                                                weightFirst += 3;
                                                break;
                                            case 'n':
                                                weightFirst += 4;
                                                break;
                                            case 'k':
                                                weightFirst += 1;
                                                break;
                                            case 'p':
                                                weightFirst += 5;
                                                break;
                                            default:
                                                break;
                                        }
                                        switch (letters[l])
                                        {
                                            case 's':
                                                weightFirst += 3;
                                                break;
                                            case 'n':
                                                weightFirst += 4;
                                                break;
                                            case 'k':
                                                weightFirst += 1;
                                                break;
                                            case 'p':
                                                weightFirst += 5;
                                                break;
                                            default:
                                                break;
                                        }

                                        switch (letters[m])
                                        {
                                            case 's':
                                                weightSecond += 3;
                                                break;
                                            case 'n':
                                                weightSecond += 4;
                                                break;
                                            case 'k':
                                                weightSecond += 1;
                                                break;
                                            case 'p':
                                                weightSecond += 5;
                                                break;
                                            default:
                                                break;
                                        }
                                        switch (letters[n])
                                        {
                                            case 's':
                                                weightSecond += 3;
                                                break;
                                            case 'n':
                                                weightSecond += 4;
                                                break;
                                            case 'k':
                                                weightSecond += 1;
                                                break;
                                            case 'p':
                                                weightSecond += 5;
                                                break;
                                            default:
                                                break;
                                        }
                                        switch (letters[p])
                                        {
                                            case 's':
                                                weightSecond += 3;
                                                break;
                                            case 'n':
                                                weightSecond += 4;
                                                break;
                                            case 'k':
                                                weightSecond += 1;
                                                break;
                                            case 'p':
                                                weightSecond += 5;
                                                break;
                                            default:
                                                break;
                                        }
                                        switch (letters[q])
                                        {
                                            case 's':
                                                weightSecond += 3;
                                                break;
                                            case 'n':
                                                weightSecond += 4;
                                                break;
                                            case 'k':
                                                weightSecond += 1;
                                                break;
                                            case 'p':
                                                weightSecond += 5;
                                                break;
                                            default:
                                                break;
                                        }
                                        if (diff == Math.Abs(weightFirst - weightSecond))
                                        {
                                            Console.WriteLine("" + letters[i] + letters[j] + letters[k] + letters[l] + letters[m] + letters[n] + letters[p] + letters[q]);
                                            matchings++;
                                        }
                                        weightFirst = 0;
                                        weightSecond = 0;
                                        
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        if (matchings == 0)
        {
            Console.WriteLine("No");
        }
    }
}
