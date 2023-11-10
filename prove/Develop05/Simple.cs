using System;
using System.Collections.Generic;

public class SimpleGoal : Goal
{
    private int _bonusPoints;
    public SimpleGoal(string name, string type, int value, int bonusPoints) : base(name, type, value)
    {
        _bonusPoints = bonusPoints;
    }
    public override void RecordEvent()
    {
        _completed = true;
        // record event for SimpleGoal
    }
}