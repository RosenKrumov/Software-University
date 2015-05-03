using System;

class LettersSymbolsNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] input = new string[n];
        int lettersSum = 0;
        int numbersSum = 0;
        int symbolsSym = 0;

        for (int i = 0; i < n; i++)
        {
            input[i] = Console.ReadLine();
            input[i] = input[i].ToLower();
            input[i] = input[i].Replace(("/t"), string.Empty);
            input[i] = input[i].Replace((" "), string.Empty);
            input[i] = input[i].Replace(("/r"), string.Empty);
            input[i] = input[i].Replace(("/n"), string.Empty);
            for (int j = 0; j < input[i].Length; j++)
            {
                switch ((input[i])[j])
                {
                    case 'a':
                        lettersSum += 10;
                        break;
                    case 'b':
                        lettersSum += 20;
                        break;
                    case 'c':
                        lettersSum += 30;
                        break;
                    case 'd':
                        lettersSum += 40;
                        break;
                    case 'e':
                        lettersSum += 50;
                        break;
                    case 'f':
                        lettersSum += 60;
                        break;
                    case 'g':
                        lettersSum += 70;
                        break;
                    case 'h':
                        lettersSum += 80;
                        break;
                    case 'i':
                        lettersSum += 90;
                        break;
                    case 'j':
                        lettersSum += 100;
                        break;
                    case 'k':
                        lettersSum += 110;
                        break;
                    case 'l':
                        lettersSum += 120;
                        break;
                    case 'm':
                        lettersSum += 130;
                        break;
                    case 'n':
                        lettersSum += 140;
                        break;
                    case 'o':
                        lettersSum += 150;
                        break;
                    case 'p':
                        lettersSum += 160;
                        break;
                    case 'q':
                        lettersSum += 170;
                        break;
                    case 'r':
                        lettersSum += 180;
                        break;
                    case 's':
                        lettersSum += 190;
                        break;
                    case 't':
                        lettersSum += 200;
                        break;
                    case 'u':
                        lettersSum += 210;
                        break;
                    case 'v':
                        lettersSum += 220;
                        break;
                    case 'w':
                        lettersSum += 230;
                        break;
                    case 'x':
                        lettersSum += 240;
                        break;
                    case 'y':
                        lettersSum += 250;
                        break;
                    case 'z':
                        lettersSum += 260;
                        break;
                    case '`':
                    case '~':
                    case '!':
                    case '@':
                    case '#':
                    case '$':
                    case '%':
                    case '^':
                    case '&':
                    case '*':
                    case '(':
                    case ')':
                    case '_':
                    case '+':
                    case '{':
                    case '}':
                    case ':':
                    case '"':
                    case '|':
                    case '<':
                    case '>':
                    case '?':
                    case '-':
                    case '=':
                    case '[':
                    case ']':
                    case ';':
                    case '\'':
                    case '\\':
                    case ',':
                    case '.':
                    case '/':
                        symbolsSym += 200;
                        break;
                    case '1':
                        numbersSum += 20;
                        break;
                    case '2':
                        numbersSum += 40;
                        break;
                    case '3':
                        numbersSum += 60;
                        break;
                    case '4':
                        numbersSum += 80;
                        break;
                    case '5':
                        numbersSum += 100;
                        break;
                    case '6':
                        numbersSum += 120;
                        break;
                    case '7':
                        numbersSum += 140;
                        break;
                    case '8':
                        numbersSum += 160;
                        break;
                    case '9':
                        numbersSum += 180;
                        break;
                    default:
                        break;
                }

            }
        }
        Console.WriteLine(lettersSum);
        Console.WriteLine(numbersSum);
        Console.WriteLine(symbolsSym);
    }
}