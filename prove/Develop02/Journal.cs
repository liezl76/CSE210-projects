using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> entries = new List<Entry>();
    public void WriteNewEntry()
    {
        Console.WriteLine("Selecting a random prompt...");
        string randomPrompt = GetRandomPrompt();
        Console.WriteLine($"Prompt: {randomPrompt}");

        Console.Write("Response: ");
        string response = Console.ReadLine();

        string date = DateTime.Now.ToString("yyyy-MM-dd");

        Entry newEntry = new Entry(randomPrompt, response, date);
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
            Console.WriteLine($"Response: {entry._response}\n");
        }
    }

    public void SaveJournalToFile()
    {
        Console.Write("Enter the filename to save the journal: ");
        string journal = Console.ReadLine();

        using (StreamWriter sw = new StreamWriter(journal))
        {
            foreach (var entry in entries)
            {
                sw.WriteLine($"{entry._date}|{entry._prompt}|{entry._response}");
            }
        }

        Console.WriteLine($"Journal saved to {journal} successfully!\n");
    }

    public void LoadJournalFromFile()
    {
        Console.Write("Enter the filename to load the journal: ");
        string journal = Console.ReadLine();

        if (File.Exists(journal))
        {
            entries.Clear();

            using (StreamReader sr = new StreamReader(journal))
            {
                while (!sr.EndOfStream)
                {
                    string[] parts = sr.ReadLine().Split('|');
                    if (parts.Length == 3)
                    {
                        Entry loadedEntry = new Entry(parts[1], parts[2], parts[0]);
                        entries.Add(loadedEntry);
                    }
                }
            }

            Console.WriteLine($"Journal loaded from {journal} successfully!\n");
        }
        else
        {
            Console.WriteLine($"File {journal} not found.\n");
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