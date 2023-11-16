using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.IO;

class Program
{
    private static List<Goal> goals = new List<Goal>();

    public static void Main(string[] args)
    {
        bool exitProgram = false;
        while (!exitProgram)
        {
            Console.WriteLine("Welcome to the Eternal Quest Program!");
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create new Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Load Goals");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.WriteLine("Enter your choice:");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CreateNewGoal();
                    break;
                case 2:
                    ListGoals();
                    break;
                case 3:
                    LoadGoals();
                    break;
                case 4:
                    SaveGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    exitProgram = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            if (!exitProgram)
            {
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
            }
        }
    }

    public static void CreateNewGoal()
    {
        Console.WriteLine("What type of goal would you like to create?");
        Console.WriteLine("Select from the menu: ");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        int goalType = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("What is the name of your goal?: ");
        string goalname = Console.ReadLine();

        Console.WriteLine("What is the short description of it?: ");
        string description = Console.ReadLine();

        Console.WriteLine("Enter goal points: ");
        int points = Convert.ToInt32(Console.ReadLine());

        switch (goalType)
        {
            case 1:
                goals.Add(new SimpleGoal(goalname, description, points));
                break;
            case 2:
                goals.Add(new EternalGoal(goalname, description, points));
                break;
            case 3:
                Console.WriteLine("Enter target count:");
                int targetCount = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter bonus points:");
                int bonusPoints = Convert.ToInt32(Console.ReadLine());

                goals.Add(new ChecklistGoal(goalname, description, points, targetCount, bonusPoints));
                break;
            default:
                Console.WriteLine("Invalid goal type. Please try again.");
                break;
        }

        Console.WriteLine("Goal created successfully.");
        Console.WriteLine();
    }

    public static void ListGoals()
    {
        Console.WriteLine("Goals:");

        foreach (var goal in goals)
        {
            Console.Write(goal._goalName + " - ");

            if (goal.IsComplete())
            {
                Console.Write("[X]");
            }
            else
            {
                Console.Write("[ ]");
            }

            if (goal is ChecklistGoal checklistGoal)
            {
                Console.Write(" Completed " + checklistGoal._currentCount + "/" + checklistGoal._targetCount + " times");
            }

            Console.WriteLine();
        }
    }

    public static void LoadGoals()
    {
        Console.WriteLine("Loading goals...");
        string file = "goals.txt";

        if (File.Exists(file))
        {
            goals.Clear();

            using (StreamReader reader = new StreamReader(file))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Parse the line and create a new Goal object
                    string[] parts = line.Split(" - ");

                    string name = parts[0].Substring(parts[0].IndexOf(": ") + 2);
                    string description = parts[1].Substring(parts[1].IndexOf(": ") + 2);

                    //Goal newGoal = new Goal(name, description);

                    // Add the new Goal object to the goals list
                    //goals.Add(newGoal);
                }
            }

            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("No goals file found.");
        }

        Console.WriteLine();
    }

    public static void SaveGoals()
    {
        Console.WriteLine("Saving the files...");
        string file = "goals.txt";
        
        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (Goal goals in goals)
            {
                writer.WriteLine($"Goal: {goals._goalName}");
                writer.WriteLine($"Description: {goals._description}");
                writer.WriteLine($"Points: {goals._points}");  
            }
        } 
    }

    public static void RecordEvent()
    {
        Console.WriteLine("Enter goal number to record event:");
        int goalNumber = Convert.ToInt32(Console.ReadLine()) - 1;

        if (goalNumber >= 0 && goalNumber < goals.Count)
        {
            Goal selectedGoal = goals[goalNumber];
            int pointsEarned = selectedGoal.RecordEvent();
            Console.WriteLine("Points earned: " + pointsEarned);
        }
        else
        {
            Console.WriteLine("Invalid goal number. Please try again.");
        }
    }
}