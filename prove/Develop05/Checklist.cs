using System;
using System.Collections.Generic;

public class ChecklistGoal : Goal
{
    private int _desireAmount;
    private int _currentCount;

    public ChecklistGoal(string name, string type, int value, int desireAmount) : base(name, type, value)
    {
        _desireAmount = desireAmount;
        _currentCount = 0;
    }
    public override void RecordEvent()
    {
        _currentCount++;
        if (_currentCount >= _desireAmount)
        {
            markCompleted();
        }
    }
    public new bool IsCompleted()
    {
        return _currentCount >= _desireAmount;
    }
}