using System;
using System.Collections.Generic;

public class EternalGoal : Goal
{
    public EternalGoal(string goalName, string description, int points) : base(goalName, description, points)
    {
    }
    public override void ListGoals()
    {
        Console.WriteLine($"[ ] {_goalName} (Eternal)");
    }
    public override void RecordEvent()
    {
        Console.WriteLine($"Congratulations! You earned {_points} points for the eternal goal '{_goalName}'.");
    }

    public override bool IsComplete()
    {
        return false;
    }
}