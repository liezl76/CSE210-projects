using System;
using System.Collections.Generic;

public abstract class Goal
{
    protected string _goalName;
    protected int _points;
    public bool completed;

    public string goalName { get; internal set; }
    public string goalDescription { get; internal set; }

    public int Points { get; internal set; }

    public Goal(string goalName, int points)
    {
        _goalName = goalName;
        _points = points;
        completed = false;
    }

    // Abstract method to record an event for the goal
    public abstract void RecordEvent();

    // Abstract method for displaying the goal's status
    public abstract void DisplayStatus();
}