using System;
using System.Collections.Generic;
using System.IO;

class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }
}

class Journal
{
    private List<JournalEntry> entries;

    public Journal()
    {
        entries = new List<JournalEntry>();
    }

    public void AddEntry(JournalEntry entry)
    {
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}");
            Console.WriteLine();
        }
    }

    public void SaveToFile(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"Date: {entry.Date}");
                writer.WriteLine($"Prompt: {entry.Prompt}");
                writer.WriteLine($"Response: {entry.Response}");
                writer.WriteLine();
            }
        }
    }

    public void LoadFromFile(string filePath)
    {
        entries.Clear();

        using (StreamReader reader = new StreamReader(filePath))
        {
            while (reader.Peek() >= 0)
            {
                string date = reader.ReadLine()?.Substring(6);
                string prompt = reader.ReadLine()?.Substring(8);
                string response = reader.ReadLine()?.Substring(10);
                reader.ReadLine();

                JournalEntry entry = new JournalEntry
                {
                    Date = DateTime.Parse(date),
                    Prompt = prompt,
                    Response = response
                };

                entries.Add(entry);
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Write new entry");
            Console.WriteLine("2. Display journal entries");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    JournalEntry newEntry = new JournalEntry();

                    Console.Write("Enter prompt: ");
                    newEntry.Prompt = Console.ReadLine();

                    Console.Write("Enter response: ");
                    newEntry.Response = Console.ReadLine();

                    newEntry.Date = DateTime.Now;

                    journal.AddEntry(newEntry);

                    Console.WriteLine("Entry added.");
                    Console.WriteLine();
                    break;

                case "2":
                    journal.DisplayEntries();
                    break;

                case "3":
                    Console.Write("Enter file path: ");
                    string saveFilePath = Console.ReadLine();

                    journal.SaveToFile(saveFilePath);

                    Console.WriteLine("Journal saved to file.");
                    Console.WriteLine();
                    break;

                case "4":
                    Console.Write("Enter file path: ");
                    string loadFilePath = Console.ReadLine();

                    journal.LoadFromFile(loadFilePath);

                    Console.WriteLine("Journal loaded from file.");
                    Console.WriteLine();
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.WriteLine();
                    break;
            }
        }
    }
}
