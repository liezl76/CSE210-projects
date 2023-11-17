using System;
using System.Collections.Generic;

public abstract class Goal
{
    public string _goalName;
    public string _description;
    public int _points;
    public bool completed;

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