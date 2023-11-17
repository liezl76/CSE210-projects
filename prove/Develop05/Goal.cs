using System;
using System.Collections.Generic;

public abstract class Goal
{
    public string _goalName;
    public int _goalType ;
    public string _description;
    public int _points;
    public bool completed;

    public Goal(string goalName, int goalType, string description, int points)
    {
        _goalName = goalName;
        _goalType = goalType;
        _description = description;
        _points = points;
        completed = false;
    }

    // Abstract method to record an event for the goal
    public abstract int RecordEvent();

    // Abstract method to check if the goal is complete
    public  abstract bool IsComplete();
}