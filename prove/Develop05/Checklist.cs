using System;
using System.Collections.Generic;

public class ChecklistGoal : Goal
{
    private int _requiredTimes;
    private int _completedTimes;
    private int _bonusPoints;

    public int RequiredTimes { get => _requiredTimes; internal set => _requiredTimes = value; }
    public int CompletedTimes { get => _completedTimes; internal set => _completedTimes = value; }
    public int BonusPoints { get => _bonusPoints; internal set => _bonusPoints = value; }

    public ChecklistGoal(string goalName, string goalDescription, int points, int requiredTimes, int bonusPoints) : base(goalName, goalDescription, points)
    {
        _requiredTimes = requiredTimes;
        _completedTimes = 0;
        _bonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        if (!completed)
        {
            _completedTimes++;
            Console.WriteLine($"Congratulations! You completed the goal '{goalName}' ({_completedTimes}/{_requiredTimes}) and gained {points} points.");

            if (_completedTimes == _requiredTimes)
            {
                _bonusPoints += 500;
                Console.WriteLine($"Congratulations! You achieved the required number of times for the goal '{goalName}' and gained a bonus of 500 points.");
                completed = true;
            }
        }
        else
        {
            Console.WriteLine($"You've already completed the checklist goal '{goalName}'.");
        }
    }

    public override void DisplayStatus()
    {
        Console.WriteLine($"[Completed {_completedTimes}/{_requiredTimes}] {goalName} (Checklist) - {goalDescription}");
    }

    public override string Display()
    {
        return $"Checklist goal: {goalName}, {goalDescription}, {points}, {_completedTimes}/{RequiredTimes}, {(completed ? "Completed" : "Not Completed")}";
    }
}