using System;
using System.Collections.Generic;

public abstract class Goal
{
    public string _goalName;
    protected string _type;
    public int _value;
    protected bool _completed;

    public Goal(string goalName, string type, int value)
    {
        _goalName = goalName;
        _type = type;
        _value = value;
        _completed = false;
    }
    public abstract void RecordEvent();
    public void MarkCompleted()
    {
        _completed = true;
    }
    public bool IsCompleted()
    {
        return _completed;
    }
    public override string ToString()
    {
        return "Name:" + _goalName + ", Type: " + _type + ", Value: " + _value + ", Completed: " + _completed;
    }
}