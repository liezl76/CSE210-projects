using System;
using System.Collections.Generic;
using System.IO;

public abstract class Goal
{
    private string _goalName;
    private string _goalDescription;
    private int _points;
    public bool completed;

    public string goalName { get => _goalName; internal set => _goalName = value; }
    public string goalDescription { get => _goalDescription; internal set => _goalDescription = value; }
    public int points { get => _points; internal set => _points = value; }

    public Goal(string goalName, string goalDescription, int points)
    {
        _goalName = goalName;
        _goalDescription = goalDescription;
        _points = points;
        completed = false;
    }

    public virtual void RecordEvent()
    {
        if (!completed)
        {
            Console.WriteLine($"Congratulations! You completed the goal '{goalName}' and gained {points} points.");
            completed = true;
            DisplayPoints(); // Display points earned
        }
        else
        {
            Console.WriteLine($"You've already completed the goal '{goalName}'.");
        }
    }

    private void DisplayPoints()
    {
        Console.WriteLine($"You earned {points} points for completing the goal.");
    }

    public abstract void DisplayStatus();

    public abstract string Display();

    public virtual string GetStringRepresentation()
    {
        return $"{GetType().Name}:{goalName},{goalDescription},{points},{completed}";
    }

    public static Goal CreateGoal(string goalString)
    {
        string[] parts = goalString.Split(':');
        if (parts.Length >= 2)
        {
            string type = parts[0];
            string[] details = parts[1].Split(',');

            if (details.Length >= 4)
            {
                string name = details[0];
                string description = details[1];
                int points;
                if (int.TryParse(details[2], out points))
                {
                    bool isCompleted = bool.Parse(details[3]);

                    switch (type)
                    {
                        case "SimpleGoal":
                            return new SimpleGoal(name, description, points) { completed = isCompleted };
                        case "EternalGoal":
                            return new EternalGoal(name, description, points) { completed = isCompleted };
                        case "ChecklistGoal":
                            int requiredTimes = 0;
                            int bonusPoints = 0;
                            if (details.Length >= 6)
                            {
                                int.TryParse(details[4], out requiredTimes);
                                int.TryParse(details[5], out bonusPoints);
                            }
                            return new ChecklistGoal(name, description, points, requiredTimes, bonusPoints) { completed = isCompleted };
                    }
                }
            }
        }

        // Default: return a SimpleGoal if unable to parse the input string
        return new SimpleGoal("DefaultGoal", "DefaultDescription", 0);
    }
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string goalName, string goalDescription, int points) : base(goalName, goalDescription, points)
    {
    }

    public override string Display()
    {
        return $"Simple goal: {goalName}, {goalDescription}, {points}, {(completed ? "Completed" : "Not Completed")}";
    }

    public override void DisplayStatus()
    {
        Console.WriteLine($"[{(completed ? 'X' : ' ')}] {goalName} - {goalDescription}");
    }
}

public class EternalGoal : Goal
{
    public EternalGoal(string goalName, string goalDescription, int points) : base(goalName, goalDescription, points)
    {
    }

    public override string Display()
    {
        return $"Eternal goal: {goalName}, {goalDescription}, {points}, {(completed ? "Completed" : "Not Completed")}";
    }

    public override void DisplayStatus()
    {
        Console.WriteLine($"[{(completed ? 'X' : ' ')}] {goalName} (Eternal) - {goalDescription}");
    }
}

public class ChecklistGoal : Goal
{
    private int _requiredTimes;
    private int _completedTimes;
    private int _bonusPoints;

    public int RequiredTimes { get => _requiredTimes; internal set => _requiredTimes = value; }
    public int CompletedTimes { get => _completedTimes; internal set => _completedTimes = value; }
    public int BonusPoints { get => _bonusPoints; internal set => _bonusPoints = value; }

    public ChecklistGoal(string goalName, string goalDescription, int points, int requiredTimes, int bonusPoints) : base(goalName, goalDescription, points)
    {
        _requiredTimes = requiredTimes;
        _completedTimes = 0;
        _bonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        if (!completed)
        {
            _completedTimes++;
            Console.WriteLine($"Congratulations! You completed the goal '{goalName}' ({_completedTimes}/{_requiredTimes}) and gained {points} points.");

            if (_completedTimes == _requiredTimes)
            {
                _bonusPoints += 500;
                Console.WriteLine($"Congratulations! You achieved the required number of times for the goal '{goalName}' and gained a bonus of 500 points.");
                completed = true;
            }
        }
        else
        {
            Console.WriteLine($"You've already completed the checklist goal '{goalName}'.");
        }
    }

    public override void DisplayStatus()
    {
        Console.WriteLine($"[Completed {_completedTimes}/{_requiredTimes}] {goalName} (Checklist) - {goalDescription}");
    }

    public override string Display()
    {
        return $"Checklist goal: {goalName}, {goalDescription}, {points}, {_completedTimes}/{RequiredTimes}, {(completed ? "Completed" : "Not Completed")}";
    }
}

class Program
{
    private static List<Goal> goals = new List<Goal>();

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
                Console.WriteLine("Enter bonus points");
                int bonusPoints = Convert.ToInt32(Console.ReadLine());
                goals.Add(new ChecklistGoal(goalName, goalDescription, points, requiredTimes, bonusPoints));
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
            DisplayScore();
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
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved to goals.txt");
    }

    private static void LoadGoals()
    {
        string filename = "goals.txt";

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                Goal goal = Goal.CreateGoal(line);
                goals.Add(goal);
            }

            DisplayLoadedGoals();
        }
        else
        {
            Console.WriteLine("No goals file found.");
        }
    }

    private static void DisplayLoadedGoals()
    {
        Console.WriteLine("Loaded Goals:");
        foreach (var goal in goals)
        {
            Console.WriteLine(goal.Display());
        }
    }
}
