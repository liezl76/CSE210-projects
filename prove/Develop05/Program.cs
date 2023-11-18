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
    public static void SaveGoals()
    {
        Console.WriteLine("Saving the goals...");
        string file = "goals.txt";

        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (var goal in goals)
            {
                writer.WriteLine($"Goal: {goal.goalName}");
                writer.WriteLine($"Description: {goal.description}");
                writer.WriteLine($"Points: {goal.points}");
                writer.WriteLine($"Completed Goals: {goal.completed}");
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }
    public static void LoadGoals()
    {
        Console.WriteLine("Loading the goals....");
        string file = "goals.txt";

        using (StreamReader reader = new StreamReader(file))
        {
            while (reader.Peek() >= 0)
            {
                string goalName = reader.ReadLine()?.Substring(6);
                string description = reader.ReadLine()?.Substring(13);
                int points = Convert.ToInt32(reader.ReadLine()?.Substring(8));
                bool completed = Convert.ToBoolean(reader.ReadLine()?.Substring(17));

                // Create a new instance 
                Goal goal;
                if (goalName == "SimpleGoal")
                {
                    goal = new SimpleGoal(goalName, description, points);
                }
                else if (goalName == "EternalGoal")
                {
                    goal = new EternalGoal(goalName, description, points);
                }
                else if (goalName == "ChecklistGoal")
                {
                    int requiredTimes = Convert.ToInt32(reader.ReadLine()?.Substring(21));
                    int completedTimes = Convert.ToInt32(reader.ReadLine()?.Substring(18));
                    goal = new ChecklistGoal(goalName, description, points, requiredTimes, completedTimes);
                }
                else
                {
                    Console.WriteLine($"Invalid goal type: {goalName}. Skipping...");
                    continue;
                }

                goal.completed = completed;
                goals.Add(goal);
            }
        }
        Console.WriteLine("Goals loaded successfully.");
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