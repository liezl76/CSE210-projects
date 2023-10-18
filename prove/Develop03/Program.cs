using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {       
        //Print the book, chapter, and verses
        Reference r1 = new Reference("Philippians", 4, 13);
        Console.WriteLine(r1.GetReferenceString());

        //print the phrase
        Word w1 = new Word();
        Console.WriteLine(w1.WordHidden());
        Console.WriteLine();
    }
}