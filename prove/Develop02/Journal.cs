using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Journal
{
    public int _choice;
    public int _result;
        
    public void MenuDisplay()
    {
        Console.WriteLine("\nPlease select one of the following: ");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");

        Console.Write("\nEnter your choice:\t");
        _choice = Convert.ToInt32(Console.ReadLine());

        if (_choice == 1)
        {
    
        }
    }
    public void SaveToFile(List<Entry> journal)
    {
        Console.WriteLine("Saving to file....");

        string filename = "journal.txt";

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry j in journal)
            {
                outputFile.WriteLine();
            }
        }

    }
    public static List<Entry> ReadFromFile()
    {
        Console.WriteLine("Reading list from file....");
        List<Entry> entries = new List<Entry>();
        string filename = "journal.txt";

        string[] lines = System.IO.File.ReadAllLines(filename);

        return entries;
    }
} 