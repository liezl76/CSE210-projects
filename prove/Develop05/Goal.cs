using System;
using System.Collections.Generic;

public abstract class Goal
{
    public string _goalName { get; set; }
    public string _description { get; set; }
    public int _points { get; set; }

    public Goal(string goalName, string description, int points)
    {
        _goalName = goalName;
        _description = description;
        _points = points;
    }

    // Abstract method to record an event for the goal
    public abstract int RecordEvent();

    // Abstract method to check if the goal is complete
    public abstract bool IsComplete();
}