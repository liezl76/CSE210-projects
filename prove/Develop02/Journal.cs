using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> entries = new List<Entry>();
    public string[] questions = {
        "Who was the most interesting person I interacted with today?",
        "If I had one thing that I could do over today, what would it be?",
        "Who was the best part of the day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?"
    };

    public void MenuDisplay()
    {
        bool isRunning = true;
        while (isRunning)
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
                    entries.Add(new Entry(answer));
                    break;
                case 2:
                    foreach(Entry ent in entries)
                    {
                        Console.WriteLine("Date: " + ent.getDateTime() + " " + "Answer: " + ent.getEntry());
                    }
                    break;
                case 3:
                    Console.WriteLine("Loading from the file...");
                    string filename = "journal.txt";

                    string[] lines = System.IO.File.ReadAllLines(filename);

                    foreach (Entry ent in entries)
                        {
                            Console.WriteLine("Date: " + ent.getDateTime() + " " + "Answer: " + ent.getEntry());
                            Console.ReadLine();
                        }
                    break;
                case 4:
                    Console.WriteLine("Saving the file...");
                    string file = "journal.txt";

                    using (StreamWriter outputFile = new StreamWriter(file))
                    {
                        foreach (Entry ent in entries)
                        {
                            outputFile.WriteLine("Date: " + ent.getDateTime() + " " + "Answer: " + ent.getEntry() + "\n");
                        }
                    }
                    break;
                case 5:
                    isRunning = false;
                    break;
                default:
                    
                    break;
            }
        }
    }
    public void DisplayWelcomeMessage()
    {
        Console.WriteLine("\nWelcome to the program!\n");
    }
}
