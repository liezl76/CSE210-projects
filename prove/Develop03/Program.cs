using System;
using System.Runtime.Intrinsics.Arm;

class Program
{
    static void Main(string[] args)
    {
        //Print the book, chapter, and verses
        Reference r1 = new Reference();
        Console.WriteLine(r1.GetBookString());
    }
}