using System;
using System.Text;
using System.Text.RegularExpressions;

class ExtractURLFromText
{
    static void Main()
    {
        string input = Console.ReadLine();
        Regex r = new Regex(@"(?<url>(http:|https:[/][/]|www.)([a-z]|[A-Z]|[0-9]|[/.]|[~])*)");

        MatchCollection matchings = r.Matches(input);

        foreach (Match match in matchings)
        {
            Console.WriteLine(match);
        }
    }
}