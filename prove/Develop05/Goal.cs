using System;
using System.Collections.Generic;

public abstract class Goal
{
    public string _name;
    protected string _type;
    protected int _value;
    protected bool _completed;

    public Goal(string name, string type, int value)
    {
        _name = name;
        _type = type;
        _value = value;
        _completed = false;
    }
    public abstract void RecordEvent();
    public void markCompleted()
    {
        _completed = true;
    }
    public bool IsCompleted()
    {
        return _completed;
    }
    public override string ToString()
    {
        return "Name:" + _name + ", Type: " + _type + ", Value: " + _value + ", Completed: " + _completed;
    }
}