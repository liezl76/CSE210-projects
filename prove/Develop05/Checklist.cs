using System;
using System.Collections.Generic;

public class ChecklistGoal : Goal
{
    public int _targetCount { get; set; }
    public int _currentCount { get; set; }
    public int _bonusPoints { get; set; }

    public ChecklistGoal(string goalName, string description, int points, int targetCount, int bonusPoints) : base(goalName, description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _currentCount = 0;
    }

    public override int RecordEvent()
    {
        Console.WriteLine("You recorded progress for the checklist goal: " + _goalName);
        _currentCount++;

        if (_currentCount == _targetCount)
        {
            Console.WriteLine("Congratulations! You completed the checklist goal: " + _goalName);
            return _points + _bonusPoints;
        }

        return _points;
    }

    public override bool IsComplete()
    {
        return _currentCount >= _targetCount;
    }
}