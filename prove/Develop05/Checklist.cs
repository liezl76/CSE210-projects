using System;
using System.Collections.Generic;

public class ChecklistGoal : Goal
{
    public int _requiredTimes { get; set; }
    public int _completedTimes { get; set; }
    public int _bonusPoints { get; set; }

    public ChecklistGoal(string goalName, string description, int points, int requiredTimes, int completedTimes) : base(goalName, description, points)
    {
        _requiredTimes = requiredTimes;
        _completedTimes = completedTimes;
        _bonusPoints = 0;
    }

    public override void ListGoals()
    {
        Console.WriteLine($"[{_completedTimes}/{_requiredTimes}] {_goalName} (Checklist)");
    }

    public override void RecordEvent()
    {
        _completedTimes++;
        Console.WriteLine($"Congratulations! You completed the goal '{_goalName}' ({_completedTimes}/{_requiredTimes}) and gained {_bonusPoints} points.");

        if (_completedTimes == _requiredTimes)
        {
            _bonusPoints += 500; // Bonus points for completing the goal
            Console.WriteLine($"Congratulations! You achieved the required number of times for the goal '{_goalName}' and gained a bonus of 500 points.");
        }
    }

    public override bool IsComplete()
    {
        return _completedTimes >= _requiredTimes;
    }
}