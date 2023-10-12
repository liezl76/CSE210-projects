using System;

class Program
{
    static void Main(string[] args)
    {
        string phrase = "The quick brown fox jumps over the lazy dog.";
        string[] words = phrase.Split(' ');

        foreach (var word in words)
        {
            System.Console.WriteLine($"<{word}>");
        }
    }
}