using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Journal
{
    List<Entry> entries = new List<Entry>();
    
    String[] questions = {
        "Who was the most interesting person I interacted with today?",
        "Who was the best part of the day?",
        "How did I see the hand ofthe Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing that I could do over today, what would it be?"
    };
      
    public void MenuDisplay()
    {
        Console.WriteLine("\nPlease select one of the following: ");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");
        Console.WriteLine();
        Console.WriteLine("What would you like to do? ");
        int choice = Int32.Parse(Console.ReadLine());

        switch(choice)
        {
            case 1:
               Random rnd = new Random();
               int num_question = rnd.Next(0, 4);
               string selected_question = questions[num_question];
               Console.WriteLine(selected_question);
               string answer = Console.ReadLine();
               SaveToFile(answer);
               Console.WriteLine(entries);
               break;
            default:
                Console.WriteLine("Thank you");
                break;
        }
    }
    public void SaveToFile(string answer)
    {
        Entry entry = new Entry();
        entry.setEntry(answer);
        entries.Add(entry);
    }

    // public static List<Entry> ReadFromFile()
    // {
    //     Console.WriteLine("Reading list from file....");
    //     List<Entry> entries = new List<Entry>();
    //     string filename = "journal.txt";

    //     string[] lines = System.IO.File.ReadAllLines(filename);

    //     return entries;
    // }

} 