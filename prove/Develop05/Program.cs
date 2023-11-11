using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Scoreboard scoreboard = new Scoreboard();

        SimpleGoal simpleGoal = new SimpleGoal("Simple Goal", "Simple", 100, 10);
        EternalGoal eternalGoal = new EternalGoal("Eternal Goal", "Eternal", 200, 5);
        ChecklistGoal checklistGoal = new ChecklistGoal("Checllist Goal", "Checklist", 300, 3);

        scoreboard.AddGoal(simpleGoal);
        scoreboard.AddGoal(eternalGoal);
        scoreboard.AddGoal(checklistGoal);

        scoreboard.RecordEvent("Simple Goal");
        scoreboard.RecordEvent("Eternal Goal");
        scoreboard.RecordEvent("Checklist Goal");
        scoreboard.RecordEvent("Checklist Goal");
        scoreboard.RecordEvent("Checklist Goal");
        
        bool exitProgram = false;
        while (!exitProgram)
        {
            Console.Clear(); //Clear the console screen
            Console.WriteLine("Welcome to the Eternal Quest Program!");
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create new Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Load Goals");
            Console.WriteLine("4. Record Events");
            Console.WriteLine("5. Exit\n");
            Console.WriteLine();
            Console.WriteLine("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch(choice)
            {
                case "1":
                    Console.Clear();
                    //breathingActivity.Start();
                    break;
                case "2":
                    Console.Clear();
                    //reflectionActivity.Start();
                    break;
                case "3":
                    Console.Clear();
                    //listingActivity.Start();
                    break;
                case "4":
                    Console.Clear();
                    //
                    break;
                case "5":
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
        //scoreboard.DisplayGoals();
        //scoreboard.DisplayScore();
    }
}