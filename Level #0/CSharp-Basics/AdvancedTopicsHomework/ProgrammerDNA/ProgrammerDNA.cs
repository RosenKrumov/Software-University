using System;

class ProgrammerDNA
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        char letter = char.Parse(Console.ReadLine());
        int fullBlocks = N / 7;
        int remainingBlocks = N % 7;

        for (int i = 1; i <= fullBlocks; i++)
        {
            for (int j = 1, dots = 3; j <= 3; j++, dots--)
            {
                Console.Write(new string('.', dots));
                for (int k = 1; k <= 2 * j - 1; k++)
                {
                    Console.Write(letter);
                    letter = GetNextLetter(letter);
                }
                Console.WriteLine(new string('.', dots));
            }

            for (int j = 0; j < 7; j++)
            {
                Console.Write(letter);
                letter = GetNextLetter(letter);
            }
            Console.WriteLine();
            for (int j = 5, dots = 1; j <= 7; j++, dots++)
            {
                Console.Write(new string('.', dots));

                for (int k = 0; k < 7 - 2 * dots; k++)
                {
                    Console.Write(letter);
                    letter = GetNextLetter(letter);
                }

                Console.WriteLine(new string('.', dots));
            }
        }

        if (remainingBlocks <= 4)
        {
            for (int i = 1, dots = 3; i <= remainingBlocks; i++, dots--)
            {
                Console.Write(new string('.', dots));
                for (int j = 0; j < 2 * i - 1; j++)
                {
                    Console.Write(letter);
                    letter = GetNextLetter(letter);
                }
                Console.WriteLine(new string('.', dots));
            }
        }

        else
        {
            for (int i = 1, dots = 3; i <= 4; i++, dots--)
            {
                Console.Write(new string('.', dots));
                for (int j = 0; j < 2 * i - 1; j++)
                {
                    Console.Write(letter);
                    letter = GetNextLetter(letter);
                }
                Console.WriteLine(new string('.', dots));
            }

            for (int i = 1, dots = 1; i <= remainingBlocks - 4; i++, dots++)
            {
                Console.Write(new string('.', dots));
                for (int j = 0; j < 7 - 2 * dots; j++)
                {
                    Console.Write(letter);
                    letter = GetNextLetter(letter);
                }
                Console.WriteLine(new string('.', dots));
            }
        }
    }

    static char GetNextLetter(char letter)
    {
        letter++;
        if (letter > 'G')
        {
            letter = 'A';
        }
        return letter;
    }
}