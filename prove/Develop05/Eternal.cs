using System;
using System.Collections.Generic;

public class EternalGoal : Goal
{
    public EternalGoal(string goalName, int points) : base(goalName, points)
    {
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Congratulations! You earned {_points} points for the eternal goal '{_goalName}'.");
    }

    public override void DisplayStatus()
    {
        Console.WriteLine($"[ ] {_goalName} (Eternal) - {goalDescription}");
    }
}