using System;

class Illuminati
{
    static void Main()
    {
        string message = Console.ReadLine();
        string messageLower = message.ToLower().Replace(" ", string.Empty);
        int sum = 0;
        int vowels = 0;

        for (int i = 0; i < messageLower.Length; i++)
        {
            switch (messageLower[i])
            {
                case 'a':
                    sum += 65;
                    vowels++;
                    break;
                case 'e':
                    sum += 69;
                    vowels++;
                    break;
                case 'i':
                    sum += 73;
                    vowels++;
                    break;
                case 'o':
                    sum += 79;
                    vowels++;
                    break;
                case 'u':
                    sum += 85;
                    vowels++;
                    break;
                default:
                    continue;
            }
        }
        Console.WriteLine(vowels);
        Console.WriteLine(sum);
    }
}