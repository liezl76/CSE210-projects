using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class Journal
{
    public List<Entry> entries = new List<Entry>(); //make a list entry
    public string[] _questions = { //make a list of random questions to prompt in writing in case 1
        "Who was the most interesting person I interacted with today?",
        "If I had one thing that I could do over today, what would it be?",
        "What was the best part of the day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "Where have you've been today?",
        "What's the significant things you did today?"
    };
    public string _userMood = PromptUserMood();
    public void MenuDisplay() //function to display menu
    {
        bool isRunning = true; //make a loop by using isRunning variable
        while (isRunning)
        {
            Console.WriteLine("\nPlease select one of the following: ");//prompt question and make a choice what youre going to do
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.WriteLine();
            Console.WriteLine("What would you like to do? ");
            int choice = Int32.Parse(Console.ReadLine());//input choice

            switch(choice) // I did use switch coz it simplier 
            {
                case 1:
                    Random rnd = new Random();
                    int num_question = rnd.Next(0, 6);
                    string selected_question = _questions[num_question];
                    Console.WriteLine(selected_question);
                    string answer = Console.ReadLine();
                    entries.Add(new Entry(selected_question));
                    entries.Add(new Entry(answer));
                    entries.Add(new Entry(_mood));
                    break;

                case 2:
                    foreach(Entry ent in entries)
                    {
                        Console.WriteLine("Date: " + ent.getDateTime() + " : " + ent.getEntry());
                    }
                    break;

                case 3:
                    ReadFromFile();
                    break;

                case 4:
                    SaveToFile();
                    break;
                    
                case 5:
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    public void DisplayWelcomeMessage()
    {
        Console.WriteLine("\nWelcome to the program!");
    }
    public void SaveToFile()
    {
        Console.WriteLine("Saving the file...");
        string file = "journal.txt";

        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry ent in entries)
            {
                outputFile.WriteLine("Date: " + ent.getDateTime() + " : " + ent.getEntry());
            }
        }
    }
    public void ReadFromFile()
    {
        Console.WriteLine("Loading from the file...");
        List<Entry> entry = new List<Entry>();
        string filename = "journal.txt";

        string[] lines = System.IO.File.ReadAllLines(filename);

            foreach (Entry ent in entries)
            {
                Console.WriteLine("Date: " + ent.getDateTime() + " : " + ent.getEntry());
                Console.ReadLine();
            }
    }
    public static string PromptUserMood()
    {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.White;
        Console.Write("How do yo feel now? ");
        string _userMood = Console.ReadLine();

        return _userMood;
    }
}