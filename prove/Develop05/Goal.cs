using System;
using System.Collections.Generic;

public abstract class Goal
{
    protected string _goalName;

    protected string _goalDescription;
    protected int _points;
    public bool completed;

    public string goalName { get; internal set; }
    public string goalDescription { get; internal set; }

    public int points { get; internal set; }

    public Goal(string goalName, string goaldescription, int points)
    {
        _goalName = goalName;
        _goalDescription = goaldescription;
        _points = points;
        completed = false;
    }

    // Abstract method to record an event for the goal
    public abstract void RecordEvent();

    // Abstract method for displaying the goal's status
    public abstract void DisplayStatus();
}