using System;
using System.Collections.Generic;

public class ChecklistGoal : Goal
{
    private int _requiredTimes;
    private int _completedTimes;
    private int _bonusPoints;

    public int requiredTimes { get; internal set; }
    public int completedTimes { get; internal set; }
    public int bonusPoints { get; internal set; }

    public ChecklistGoal(string goalName, int points, int requiredTimes) : base(goalName, points)
    {
        _requiredTimes = requiredTimes;
        _completedTimes = 0;
        _bonusPoints = 0;
    }

    public override void RecordEvent()
    {
        _completedTimes++;
        Console.WriteLine($"Congratulations! You completed the goal '{_goalName}' ({_completedTimes}/{_requiredTimes}) and gained {_points} points.");

        if (_completedTimes == _requiredTimes)
        {
            _bonusPoints += 500; // Bonus points for completing the goal
            Console.WriteLine($"Congratulations! You achieved the required number of times for the goal '{_goalName}' and gained a bonus of 500 points.");
            completed = true;
        }
    }

    public override void DisplayStatus()
    {
        Console.WriteLine($"[Completed {_completedTimes}/{_requiredTimes}] {_goalName} (Checklist)");
    }
}