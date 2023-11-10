using System;
using System.Collections.Generic;

public class EternalGoal : Goal
{
    private int _recordCount;

    public EternalGoal(string name, string type, int value, int recordCount) : base(name, type, value)
    {
        _recordCount = recordCount;
    }
    public override void RecordEvent()
    {
        _completed = true;
        //record event for EternalGoal
    }
}