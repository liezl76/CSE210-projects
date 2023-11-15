using System;
using System.Collections.Generic;

public class SimpleGoal : Goal
{
    protected int _bonusPoints;
    public SimpleGoal(string goalName, string type, int value, int bonusPoints) : base(goalName, type, value)
    {
        _bonusPoints = bonusPoints;
    }
    public override void RecordEvent()
    {
        _completed = true;
        // record event for SimpleGoal
    }
}