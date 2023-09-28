using System;
using System.Collections.Generic;

public class Journal
{
    
    
    public static void SaveToFile(List<Entry> journal)
    {
        Console.WriteLine("Saving to file....");

        string filename = "journal.txt";

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry j in journal)
            {
                outputFile.WriteLine($"");
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