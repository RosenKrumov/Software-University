using System;

class StringsAndObjects
{
    static void Main()
    {
        string firstWord = "Hello";
        string secondWord = "World";
        object concatenatedWord = firstWord + " " + secondWord;
        string helloWorld = (string)concatenatedWord;
        Console.WriteLine(helloWorld);
    }
}