using System;
using System.Collections.Generic;

public class SimpleGoal : Goal
{
    public SimpleGoal(string goalName, string description, int points) : base(goalName, description, points)
    {
    }

    public override int RecordEvent()
    {
        Console.WriteLine("Congratulations! You completed the simple goal: " + _goalName);
        return _points;
    }

    public override bool IsComplete()
    {
        return true;
    }
}