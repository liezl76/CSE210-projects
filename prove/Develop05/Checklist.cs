using System;
using System.Collections.Generic;

public class ChecklistGoal : Goal
{
    public int _desireAmount;
    public int _currentCount;
    internal int _bonusPoints;

    public ChecklistGoal(string goalName, string type, int value, int desireAmount) : base(goalName, type, value)
    {
        _desireAmount = desireAmount;
        _currentCount = 0;
    }
    public override void RecordEvent()
    {
        _currentCount++;
        if (_currentCount >= _desireAmount)
        {
            MarkCompleted();
        }
    }
    public new bool IsCompleted()
    {
        return _currentCount >= _desireAmount;
    }
}