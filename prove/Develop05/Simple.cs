using System;
using System.Collections.Generic;

public class SimpleGoal : Goal
{
    public SimpleGoal(string goalName, string description, int points) : base(goalName, description, points)
    {
    }

    public override void ListGoals()
    {
        Console.WriteLine($"[ ] {_goalName}");
    }
    public override void RecordEvent()
    {
        Console.WriteLine($"Congratulations! You completed the goal '{_goalName}' and gained {_points} points.");
    }

    public override bool IsComplete()
    {
        return true;
    }
}