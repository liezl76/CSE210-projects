using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<string> entries = new List<string>();
    private string[] questions = {
        "Who was the most interesting person I interacted with today?",
        "Who was the best part of the day?",
        "How did I see the hand of the Lord in my life today?",
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
                    entries.Add(answer);
                    break;

                case 2:
                    foreach (string entry in entries)
                    {
                        Console.WriteLine(entry);
                    }
                    break;

                case 3:
                    entries.Clear();
                    string[] loadedLines = File.ReadAllLines("journal.txt");
                    entries.AddRange(loadedLines);
                    break;

                case 4:
                    File.WriteAllLines("journal.txt", entries);
                    break;

                case 5:
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}