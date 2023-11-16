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
            Console.WriteLine("\nWelcome to the Eternal Quest Program!");
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create new Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Load Goals");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit\n");
            Console.WriteLine("Select a choice from the menu: ");
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
        Console.WriteLine("3. Checklist Goal\n");
        int goalType = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("What is the name of your goal?: ");
        string goalName = Console.ReadLine();

        Console.WriteLine("What is the short description of it?: ");
        string description = Console.ReadLine();

        Console.WriteLine("Enter goal points: ");
        int points = Convert.ToInt32(Console.ReadLine());

        switch (goalType)
        {
            case 1:
                goals.Add(new SimpleGoal(goalName, description, points));
                break;
            case 2:
                goals.Add(new EternalGoal(goalName, description, points));
                break;
            case 3:
                Console.WriteLine("Enter target count:");
                int targetCount = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter bonus points:");
                int bonusPoints = Convert.ToInt32(Console.ReadLine());

                goals.Add(new ChecklistGoal(goalName, description, points, targetCount, bonusPoints));
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
        Console.WriteLine("Enter the file path to load goals from:");
        string filePath = Console.ReadLine();

        if (File.Exists(filePath))
        {
            goals.Clear(); // Clear the existing goals list

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string goalName = line.Replace("Goal: ", "");
                    string description = reader.ReadLine().Replace("Description: ", "");
                    int points = Convert.ToInt32(reader.ReadLine().Replace("Points: ", ""));


                    goals.Add(new SimpleGoal(goalName, description, points));
                    goals.Add(new EternalGoal(goalName, description, points));
                }
            }

            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found. Please try again.");
        }
    }

    public static void SaveGoals()
    {
        Console.WriteLine("Saving the goals...");
        string file = "goals.txt";

        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (Goal goal in goals)
            {
                writer.WriteLine($"Goal: {goal._goalName}");
                writer.WriteLine($"Description: {goal._description}");
                writer.WriteLine($"Points: {goal._points}");
            }
        }

        Console.WriteLine("Goals saved successfully.");
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