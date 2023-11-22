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