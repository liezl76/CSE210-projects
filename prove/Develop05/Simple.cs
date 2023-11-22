using System;
using System.Collections.Generic;
using System.ComponentModel;

public class SimpleGoal : Goal
{
    public SimpleGoal(string goalName, string goalDescription, int points) : base(goalName, goalDescription, points)
    {
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Congratulations! You completed the goal '{_goalName}' and gained {_points} points.");
        completed = true;
    }

    public override void DisplayStatus()
    {
        Console.WriteLine($"[{(completed ? 'X' : ' ')}] {_goalName} - {goalDescription}");
    }
    public override string Display()
    {
        return $"Simple goal: {goalName}, {goalDescription},{points}";
    }
}