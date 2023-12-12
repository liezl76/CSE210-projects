using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> entries = new List<Entry>();
    public void WriteNewEntry()
    {
        Console.WriteLine();                                                                                                                              
        string randomPrompt = GetRandomPrompt();
        Console.WriteLine($"Prompt: {randomPrompt}");

        Console.Write("Response: ");
        string response = Console.ReadLine();

        Console.Write("Location: ");
        string location = Console.ReadLine();

        string date = DateTime.Now.ToString("yyyy-MM-dd");

        Entry newEntry = new Entry(randomPrompt, response, location, date);
        entries.Add(newEntry);

        Console.WriteLine("Entry saved successfully!\n");
    }

    public void DisplayJournal()
    {
        Console.WriteLine("Journal Entries:\n");
        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry._date}");
            Console.WriteLine($"Prompt: {entry._prompt}");
            Console.WriteLine($"Response: {entry._response}");
            Console.WriteLine($"Location: {entry._location}");
        }
    }

    public void SaveJournalToFile()
    {
        Console.Write("Enter the filename to save the journal: ");
        string filename = Console.ReadLine();

        using (StreamWriter sw = new StreamWriter(filename, true))
        {
            foreach (var entry in entries)
            {
                sw.WriteLine($"{entry._date}|{entry._prompt}|{entry._response}|{entry._location}");
            }
        }
        Console.WriteLine($"Journal saved to {filename} successfully!");
    }

    public void LoadJournalFromFile()
    {
        Console.Write("Enter the filename to load the journal: ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            entries.Clear();

            using (StreamReader sr = new StreamReader(filename))
            {
                while (!sr.EndOfStream)
                {
                    string[] parts = sr.ReadLine().Split('|');
                    if (parts.Length == 4)
                    {
                        Entry loadedEntry = new Entry(parts[1], parts[2], parts[3], parts[0]);
                        entries.Add(loadedEntry);
                    }
                }
            }

            Console.WriteLine($"Journal loaded from {filename} successfully!");
        }
        else
        {
            Console.WriteLine($"File {filename} not found.\n");
        }
    }

    private string GetRandomPrompt()
    {
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        Random random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}