using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine();
        DisplayWelcomeMessage();

        bool exitProgram = false;
        while (!exitProgram)
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit\n");
            Console.WriteLine("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    new BreathingActivity().Start();
                    break;
                case "2":
                    Console.Clear();
                    new ReflectionActivity().Start();
                    break;
                case "3":
                    Console.Clear();
                    new ListingActivity().Start();
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
    }
    public static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the Mindfulness Program!");
    }
}
