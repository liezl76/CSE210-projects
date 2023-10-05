using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        myJournal.DisplayWelcomeMessage();
        myJournal.MenuDisplay();
        Console.ReadLine();
    }

}