using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    public static List<Goal> goals = new List<Goal>();

    public static void Main(string[] args)
    {
        bool quit = false;

        while (!quit)
        {
            Console.WriteLine("Options:");
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
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
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
        Console.WriteLine("Load goals ");
    }

    public static void SaveGoals()
    {
        Console.WriteLine("Save goals ");
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