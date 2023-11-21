using System;
using System.Collections.Generic;
using System.IO;

public class Goal
{
    protected string _name { get; set; }
    protected string _description { get; set; }
    protected int _points { get; set; }
    protected bool _completed { get; set; }

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _completed = false;
    }

    public bool IsCompleted()
    {
        return _completed;
    }

    public virtual void Display()
    {
        Console.WriteLine($"[{(_completed ? 'X' : ' ')}] {GetName()}");
    }

    public virtual void RecordEvent()
    {
        Console.WriteLine($"Congratulations! You have earned {GetPoints()} points for completing {GetName()}.");
        _completed = true;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetPoints()
    {
        return _points;
    }

        public string GetDescription()
    {
        return _description;
    }

}

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    // Override the RecordEvent method for eternal goals
    public override void RecordEvent()
    {
        Console.WriteLine($"Congratulations! You have earned {_points} points for {_name}.");
    }
}

public class ChecklistGoal : Goal
{
    public int _requiredTimes { get; private set; }
    public int _bonusPoints { get; private set; }

    public ChecklistGoal(string name, string description, int points, int requiredTimes, int bonusPoints) : base(name, description, points)
    {
        _requiredTimes = requiredTimes;
        _bonusPoints = bonusPoints;
    }

    // Override the Display method for checklist goals
    public override void Display()
    {
        Console.WriteLine($"[{(_completed ? 'X' : ' ')}] {_name} --- currently completed: {_requiredTimes}/{_bonusPoints}");
    }

    // Override the RecordEvent method for checklist goals
    public override void RecordEvent()
    {
        _requiredTimes++;

        if (_requiredTimes == _bonusPoints)
        {
            Console.WriteLine($"Congratulations! You have earned {_points + _bonusPoints} points for completing {_name}.");
            _completed = true;
        }
        else
        {
            Console.WriteLine($"Congratulations! You have earned {_points} points for completing {_name} ({_requiredTimes}/{_bonusPoints}).");
        }
    }
}

class Program
{
    private static List<Goal> goals = new List<Goal>();
    private static int userPoints = 0;

    public static void Main()
    {
        LoadGoals();
        DisplayMenu();
    }

    public static void DisplayMenu()
    {
        int choice;

        do
        {
            Console.WriteLine($"You have {userPoints} points\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create new Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit\n");
            Console.Write("\nEnter your choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CreateNewGoal();
                    break;
                case 2:
                    ListGoals();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
            }
        } while (choice != 6);
    }

    public static void CreateNewGoal()
    {
        Console.WriteLine("Which type of goal would you like to create?");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");

        int goalType = int.Parse(Console.ReadLine());

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is the short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (goalType)
        {
            case 1:
                goals.Add(new SimpleGoal(name, description, points));
                break;
            case 2:
                goals.Add(new EternalGoal(name, description, points));
                break;
            case 3:
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int requiredTimes = int.Parse(Console.ReadLine());

                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonusPoints = int.Parse(Console.ReadLine());

                goals.Add(new ChecklistGoal(name, description, points, requiredTimes, bonusPoints));
                break;
        }
    }

    public static void ListGoals()
    {
        Console.WriteLine("Your Goals:");

        foreach (var goal in goals)
        {
            goal.Display();
        }
    }

    public static void SaveGoals()
    {
    using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(userPoints);

            foreach (var goal in goals)
            {
                string goalType = goal.GetType().Name;
                writer.WriteLine($"{goalType}: {goal.GetName()},{goal.GetDescription()},{goal.GetPoints()}," +
                                //$"{(goal is ChecklistGoal checklistGoal ? checklistGoal._requiredTimes : 0)}," +
                                $"{(goal is ChecklistGoal checklistGoal ? checklistGoal._bonusPoints : 0)}");
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    public static void LoadGoals()
    {
        goals.Clear();

        if (File.Exists("goals.txt"))
        {
            using (StreamReader reader = new StreamReader("goals.txt"))
            {
                userPoints = int.Parse(reader.ReadLine());

                while (!reader.EndOfStream)
                {
                    string[] goalData = reader.ReadLine().Split(':');
                    string[] details = goalData[1].Split(',');

                    switch (goalData[0])
                    {
                        case "Simple Goal":
                            goals.Add(new SimpleGoal(details[0], details[1], int.Parse(details[2])));
                            break;
                        case "Eternal Goal":
                            goals.Add(new EternalGoal(details[0], details[1], int.Parse(details[2])));
                            break;
                        case "Checklist Goal":
                            goals.Add(new ChecklistGoal(details[0], details[1], int.Parse(details[2]), int.Parse(details[3]), int.Parse(details[4])));
                            break;
                    }
                }
            }

            Console.WriteLine("Goals loaded successfully.");
        }
    }

    public static void RecordEvent()
    {
        ListGoals();
        Console.Write("Which goal would you like to accomplish? ");
        string goalName = Console.ReadLine();

        Goal goal = goals.Find(g => g.GetName().Equals(goalName, StringComparison.OrdinalIgnoreCase));

        if (goal != null)
        {
            goal.RecordEvent();
            userPoints += goal.GetPoints();

            if (goal is ChecklistGoal checklistGoal && checklistGoal.IsCompleted())
            {
                userPoints += checklistGoal._bonusPoints;
            }
        }
        else
        {
            Console.WriteLine("Goal not found.");
        }
    }
}