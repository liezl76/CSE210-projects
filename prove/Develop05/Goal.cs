using System;
using System.Collections.Generic;

public abstract class Goal
{
    protected string _goalName;
    protected string _description;
    protected int _points;
    public bool completed;

    public string goalName { get; internal set; }
    public string description { get; internal set; }
    public int points { get; internal set; }

    public Goal(string goalName, string description, int points)
    {
        _goalName = goalName;
        _description = description;
        _points = points;
        completed = false;
    }

    // Abstract method to record an event for the goal
    public abstract void RecordEvent();

    // Abstract method for the list of goals
    public abstract void ListGoals();

    // Abstract method to check if the goal is complete
    public  abstract bool IsComplete();
}