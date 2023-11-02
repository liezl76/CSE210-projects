using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> prompts = new List<string> {"Prompt 1", "Prompt 2", "Prompt 3"};
        List<string> items = new List<string>();

        //Create instances of different activities
        Activity breathingActivity = new BreathingActivity("BreathingActivity", "Perform breathing exercises", 30, "Breath in...", "Breath out...");
        Activity reflectionActivity = new ReflectionActivity("Reflection Activity", "Reflect on your thoughts", 30, prompts, new List<string> { "Question 1", "Question 2", "Question 3" });
        Activity listingActivity = new ListingActivity("Listing Activity", "List items", 90, prompts, items);

        bool exitProgram = false;
        while (!exitProgram)
        {
            Console.Clear(); //Clear the console screen
            Console.WriteLine("Welcome to the Activity Program!");
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit\n");
            Console.WriteLine();
            Console.WriteLine("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch(choice)
            {
                case "1":
                    Console.Clear();
                    breathingActivity.Start();
                    break;
                case "2":
                    Console.Clear();
                    reflectionActivity.Start();
                    break;
                case "3":
                    Console.Clear();
                    listingActivity.Start();
                    break;
                case "4":
                    exitProgram = true;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice. Please try again.\n");
                    break;
            }
            if (!exitProgram)
            {
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
            }
        }
        Console.WriteLine("Goodbye!\n");
    }
}