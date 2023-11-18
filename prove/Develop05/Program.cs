using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.IO;

class Program
{
    private static List<Goal> goals = new List<Goal>();
    private static string goalsFilePath = "goals.txt";

    public static void Main()
    {
        LoadGoals();

        bool exitProgram = false;

        while (!exitProgram)
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create new Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Quit\n");

            Console.Write("Select a choice from the menu: ");
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
                    RecordEvent();
                    break;
                case 4:
                    DisplayScore();
                    break;
                case 5:
                    SaveGoals();
                    break;
                case 6:
                    LoadGoals();
                    break;
                case 7:
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

    private static void CreateNewGoal()
{
    Console.WriteLine("What type of goal would you like to create?");
    Console.WriteLine("1. Simple Goal");
    Console.WriteLine("2. Eternal Goal");
    Console.WriteLine("3. Checklist Goal");
    Console.Write("Enter your choice: ");
    int goalTypeChoice = Convert.ToInt32(Console.ReadLine());

    Console.Write("What is the name of your goal?: ");
    string goalName = Console.ReadLine();

    Console.Write("Enter a description for your goal: ");
    string goalDescription = Console.ReadLine();

    Console.Write("Enter goal points: ");
    int points = Convert.ToInt32(Console.ReadLine());

    switch (goalTypeChoice)
    {
        case 1:
            goals.Add(new SimpleGoal(goalName, points) {goalDescription = goalDescription});
            break;
        case 2:
            goals.Add(new EternalGoal(goalName, points) { goalDescription = goalDescription });
            break;
        case 3:
            Console.Write("Enter the required number of times for the goal: ");
            int requiredTimes = Convert.ToInt32(Console.ReadLine());
            goals.Add(new ChecklistGoal(goalName, points, requiredTimes) { goalDescription = goalDescription });
            break;
        default:
            Console.WriteLine("Invalid goal type. Please try again.");
            break;
    }

    Console.WriteLine("Goal created successfully.");
}

    private static void ListGoals()
    {
        Console.WriteLine("Current Goals:");
        foreach (var goal in goals)
        {
            goal.DisplayStatus();
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

    private static void DisplayScore()
    {
        int totalScore = 0;
        foreach (var goal in goals)
        {
            if (goal.completed)
            {
                totalScore += goal.Points;
            }
        }

        Console.WriteLine($"Your total score is: {totalScore}");
    }

    private static void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter(goalsFilePath))
        {
            foreach (var goal in goals)
            {
                writer.WriteLine($"{goal.GetType().Name},{goal.goalName},{goal.Points},{goal.completed}");

                if (goal is ChecklistGoal checklistGoal)
                {
                    writer.WriteLine($"{checklistGoal.requiredTimes},{checklistGoal.completedTimes},{checklistGoal.bonusPoints}");
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
                int points = int.Parse(parts[2]);
                bool completed = bool.Parse(parts[3]);

                Goal goal;

                switch (goalType)
                {
                    case nameof(SimpleGoal):
                        goal = new SimpleGoal(goalName, points);
                        break;
                    case nameof(EternalGoal):
                        goal = new EternalGoal(goalName, points);
                        break;
                    case nameof(ChecklistGoal):
                        int requiredTimes = int.Parse(parts[4]);
                        int completedTimes = int.Parse(parts[5]);
                        int bonusPoints = int.Parse(parts[6]);
                        goal = new ChecklistGoal(goalName, points, requiredTimes);
                        ((ChecklistGoal)goal)._completedTimes = completedTimes;
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
}