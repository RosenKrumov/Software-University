using System;

class PandaScotlandFlag
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        
        if (n == 1)
        {
            Console.WriteLine("A");
        }
        else
        {
            Console.Write("A");
            Console.Write(new string('#', n - 2));
            Console.WriteLine("B");
            char letter = 'B';

            for (int i = 0, inner = n - 2; i < n / 2 - 1; i++, inner -= 2)
            {
                Console.Write(new string('~', i + 1));
                letter = GetNextLetter(letter);
                Console.Write(letter);
                Console.Write(new string('#', inner - 2));
                letter = GetNextLetter(letter);
                Console.Write(letter);
                Console.WriteLine(new string('~', i + 1));
            }

            Console.Write(new string('-', n / 2));
            letter = GetNextLetter(letter);
            Console.Write(letter);
            Console.WriteLine(new string('-', n / 2));

            for (int i = n / 2 + 1, inner = 1; i < n; i++, inner += 2)
            {
                Console.Write(new string('~', n - i - 1));
                letter = GetNextLetter(letter);
                Console.Write(letter);
                Console.Write(new string('#', inner));
                letter = GetNextLetter(letter);
                Console.Write(letter);
                Console.WriteLine(new string('~', n - i - 1));
            }
        }
        }
        

    static char GetNextLetter(char letter)
    {
        letter++;
        if (letter > 'Z')
        {
            letter = 'A';
        }
        return letter;
    }
}