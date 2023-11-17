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
    private static void ListGoals()
    {
        Console.WriteLine("Current Goals:");
        foreach (var goal in goals)
        {
            goal.ListGoals();
        }
        Console.WriteLine();
    }

    private static void RecordEvent()
    {
        Console.Write("Enter the index of the goal you completed: ");
        int index = Convert.ToInt32(Console.ReadLine());

        if (index >= 0 && index < goals.Count)
        {
            Goal goal = goals[index];
            goal.RecordEvent();
        }
        else
        {
            Console.WriteLine("Invalid goal index. Please try again.");
        }
    }

    public static void SaveGoals(object goalName, object description, object points)
    {
        Console.WriteLine("Saving the goals...");
        string file = "goals.txt";

        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (Goal goal in goals)
            {
                writer.WriteLine($"Goal: {goalName}");
                writer.WriteLine($"Description: {description}");
                writer.WriteLine($"Points: {points}");
                writer.WriteLine($"Completed Goals: {goal.completed}");
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    private static void LoadGoals()
    {
        Console.WriteLine("Enter the file path to load goals from: ");
        string filePath = Console.ReadLine();

        try
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] goalData = line.Split(';');

                if (goalData.Length >= 4)
                {
                    string goalType = goalData[0];
                    string goalName = goalData[1];
                    string description = goalData[2];
                    int points = Convert.ToInt32(goalData[3]);

                    switch (goalType)
                    {
                        case "SimpleGoal":
                            goals.Add(new SimpleGoal(goalName, description, points));
                            break;
                        case "EternalGoal":
                            goals.Add(new EternalGoal(goalName, description, points));
                            break;
                        case "ChecklistGoal":
                            if (goalData.Length >= 5)
                            {
                                int requiredTimes = Convert.ToInt32(goalData[4]);
                                int completedTimes = Convert.ToInt32(goalData[5]);
                                goals.Add(new ChecklistGoal(goalName, description, points, requiredTimes, completedTimes));
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid goal type: " + goalType);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid goal data: " + line);
                }
            }

            Console.WriteLine("Goals loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading goals: " + ex.Message);
        }
    }

    private static void CreateNewGoal()
    {
        Console.WriteLine("What type of goal would you like to create?");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("Enter your choice: ");
        int choice = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("What is the name of your goal?: ");
        string goalName = Console.ReadLine();

        Console.WriteLine("What is the short description of it?: ");
        string description = Console.ReadLine();

        Console.WriteLine("Enter goal points: ");
        int points = Convert.ToInt32(Console.ReadLine());

        int completedTimes = 0;
        switch (choice)
        {
            case 1:
                goals.Add(new SimpleGoal (goalName, description, points));
                break;
            case 2:
                goals.Add(new EternalGoal(goalName, description, points));
                break;
            case 3:
                Console.WriteLine("Enter the required number of times for the goals: ");
                int requiredTimes = Convert.ToInt32(Console.ReadLine());
                goals.Add(new ChecklistGoal(goalName, description, points, requiredTimes, completedTimes));
                break;
            default:
                Console.WriteLine("Invalid goal type. Please try again.");
                break;
        }

        Console.WriteLine("Goal created successfully.");
        Console.WriteLine();
    }
}