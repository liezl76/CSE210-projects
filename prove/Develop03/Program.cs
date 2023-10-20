using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {       
        //Print the book, chapter, and verses
        // Reference r1 = new Reference("James", 1, 5, 6);
        // Console.WriteLine(r1.GetReferenceVerse2());

        // //Print WordHidden
        // Word w1 = new Word();
        // Console.WriteLine(w1.wordIsHidden());
        // Console.WriteLine();

        Scripture s1 = new Scripture();
        s1.ScriptureDisplay();
    }
}