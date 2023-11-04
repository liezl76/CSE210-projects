using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> prompts = new List<string> 
        {
            "Using 10 words, describe yourself.",
            "What can you learn from your biggest mistakes?",
            "Make a list of everything that inspires you.",
            "Who are the people that you appreciate?",
            "What are personal strength of yours?",
            "When have you felt the Holy Ghost this month?",
            "Who are the people that you have helped this week?",
            // Add more prompts as needed
        };
        List<string> items = new List<string>();
        List<string> promptlist = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something really selfless.",
            // Add more prompts as needed
        };
        List<string> questionlist = new List<string>()
        {
            "What surprised you the most about your life?",
            "What topic do you need to learn more about to live a more fulfilling life?",
            "Why the experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was completed?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the futre?",
            // Add more questions as needed
        };

        //Create instances of different activities
        Activity breathingActivity = new BreathingActivity("BreathingActivity", 
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on breathing. ", 
        30, "Breath in...", "Breath out...");
        Activity reflectionActivity = new ReflectionActivity("Reflection Activity", 
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", 
        3, promptlist, questionlist);
        Activity listingActivity = new ListingActivity("Listing Activity", "List items", 3, prompts, items);

        bool exitProgram = false;
        while (!exitProgram)
        {
            Console.Clear(); //Clear the console screen
            Console.WriteLine("Welcome to the Mindfulness Program!");
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
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