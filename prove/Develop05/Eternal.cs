using System;
using System.Collections.Generic;

public class EternalGoal : Goal
{
    public EternalGoal(string goalName, string description, int points) : base(goalName, description, points)
    {
    }

    public override int RecordEvent()
    {
        Console.WriteLine("You recorded progress for the eternal goal: " + _goalName);
        return _points;
    }

    public override bool IsComplete()
    {
        return false;
    }
}