using System;
using System.Collections.Generic;

public class SimpleGoal : Goal
{
    public SimpleGoal(string goalName, int points) : base(goalName, points)
    {
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Congratulations! You completed the goal '{_goalName}' and gained {_points} points.");
        completed = true;
    }

    public override void DisplayStatus()
    {
        Console.WriteLine($"[{(completed ? 'X' : ' ')}] {_goalName}");
    }
}