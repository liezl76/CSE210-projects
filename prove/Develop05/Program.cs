using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.IO;
using System.Text.Json.Serialization;

class Program
{
    private static List<Goal> goals = new List<Goal>();
    private static string goalsFilePath = "goals.txt";
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
    private static void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter(goalsFilePath))
        {
            foreach (var goal in goals)
            {
                writer.WriteLine($"{goal.GetType().Name},{goal.goalName},{goal.description},{goal.points},{goal.completed}");

                if (goal is ChecklistGoal checklistGoal)
                {
                    writer.WriteLine($"{checklistGoal._requiredTimes},{checklistGoal._completedTimes},{checklistGoal._bonusPoints}");
                }
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    private static void LoadGoals()
    {
        if (!File.Exists(goalsFilePath))
        {
            Console.WriteLine("No saved goals found.");
            return;
        }

        goals.Clear();

        using (StreamReader reader = new StreamReader(goalsFilePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');

                string goalType = parts[0];
                string goalName = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);
                bool completed = bool.Parse(parts[4]);

                Goal goal;

                switch (goalType)
                {
                    case nameof(SimpleGoal):
                        goal = new SimpleGoal(goalName, description, points);
                        break;
                    case nameof(EternalGoal):
                        goal = new EternalGoal(goalName, description, points);
                        break;
                    case nameof(ChecklistGoal):
                        int requiredTimes = int.Parse(parts[5]);
                        int completedTimes = int.Parse(parts[6]);
                        int bonusPoints = int.Parse(parts[7]);
                        goal = new ChecklistGoal(goalName, description, points, requiredTimes, completedTimes);
                        ((ChecklistGoal)goal)._bonusPoints = bonusPoints;
                        break;
                    default:
                        Console.WriteLine($"Unknown goal type: {goalType}");
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