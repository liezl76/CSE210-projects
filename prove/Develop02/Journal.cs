using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> entries = new List<Entry>();
    private string[] questions = {
        "Who was the most interesting person I interacted with today?",
        "Who was the best part of the day?",
        "How did I see the hand ofthe Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing that I could do over today, what would it be?"
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
                        Console.WriteLine("Answer: " + ent.getEntry() + " Date: " + ent.getDateTime());
                    }
                    break;
                case 3:
                    Console.WriteLine("Loading from the file...");
                    string filename = "journal.txt";

                    string[] lines = System.IO.File.ReadAllLines(filename);

                    foreach (Entry ent in entries)
                        {
                            Console.WriteLine("Answer: " + ent.getEntry() + " Date: " + ent.getDateTime());
                        }
                    break;
                case 4:
                    Console.WriteLine("Saving the file...");
                    string file = "journal.txt";

                    using (StreamWriter outputFile = new StreamWriter(file))
                    {
                        foreach (Entry ent in entries)
                        {
                            outputFile.WriteLine("Answer: " + ent.getEntry() + " Date: " + ent.getDateTime() + "\n");  
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
}
