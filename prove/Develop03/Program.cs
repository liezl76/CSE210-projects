using System;
using System.Text;

class Program
{
    // public void ScriptureDisplay()
    // {
    //     bool isRunning = true;
    //     while (isRunning)
    //     {
    //         Reference r1 = new Reference("James", 2, 5, 6);
    //         Console.WriteLine(r1.GetReferenceVerse2());

    //         Word w1 = new Word();
    //         Console.WriteLine(w1.getWord());
    //         break;
    //     }
    // }
    static void Main(string[] args)
    {       
        //Print the book, chapter, and verses
        // Reference r1 = new Reference("James", 1, 5, 6);
        // Console.WriteLine(r1.GetReferenceVerse2());

        //Print WordHidden
        Word w1 = new Word();
        Console.WriteLine(w1.wordIsHidden());
        Console.WriteLine();

        // Scripture s1 = new Scripture();
        // Console.WriteLine(s1.GetScripture());
    }
}