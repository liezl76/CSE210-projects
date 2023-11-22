using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    private static List<Goal> goals = new List<Goal>();
    private static int score = 0;

    public static void Main(string[] args)
    {
        DisplayScore();

        bool exitProgram = false;

        while (!exitProgram)
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create new Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit\n");

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
                    SaveGoals();
                    break;
                case 5:
                    LoadGoals();
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

        Console.Write("What is the description for your goal: ");
        string goalDescription = Console.ReadLine();

        Console.Write("Enter goal points: ");
        int points = Convert.ToInt32(Console.ReadLine());

        switch (goalTypeChoice)
        {
            case 1:
                goals.Add(new SimpleGoal(goalName, goalDescription, points));
                break;
            case 2:
                goals.Add(new EternalGoal(goalName, goalDescription, points));
                break;
            case 3:
                Console.Write("Enter the required number of times for the goal: ");
                int requiredTimes = Convert.ToInt32(Console.ReadLine());
                goals.Add(new ChecklistGoal(goalName, goalDescription, points, requiredTimes));
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
                totalScore += goal.points;
            }
        }

        Console.WriteLine($"Your total score is: {totalScore}");
    }

    private static void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            foreach (var goal in goals)
            {
                writer.WriteLine(goal.Display());
            }
        }

        Console.WriteLine("Goals saved to goals.txt");
    }

    private static void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            using (StreamReader reader = new StreamReader("goals.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(':');
                    if (parts.Length >= 2)
                    {
                        string type = parts[0].Trim();
                        string[] goalParts = parts[1].Split(',');

                        if (goalParts.Length >= 3)
                        {
                            string name = goalParts[0].Trim();
                            string description = goalParts[1].Trim();
                            int points = int.Parse(goalParts[2].Trim());

                            switch (type)
                            {
                                case "Simple goal":
                                    goals.Add(new SimpleGoal(name, description, points));
                                    break;
                                case "Eternal goal":
                                    goals.Add(new EternalGoal(name, description, points));
                                    break;
                                case "Checklist goal":
                                    if (goalParts.Length >= 5)
                                    {
                                        int totalTimes = int.Parse(goalParts[3].Trim());
                                        int bonus = int.Parse(goalParts[4].Trim());
                                        goals.Add(new ChecklistGoal(name, description, points, totalTimes, bonus));
                                    }
                                    break;
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Goals loaded from goals.txt");
        }
        else
        {
            Console.WriteLine("No goals file found.");
        }
    }
}