using System;
using System.Collections.Generic;

public class EternalGoal : Goal
{
    public EternalGoal(string goalName, string goalDescription, int points) : base(goalName, goalDescription, points)
    {
    }

    public override string Display()
    {
        return $"Eternal goal: {goalName}, {goalDescription}, {points}, {(completed ? "Completed" : "Not Completed")}";
    }

    public override void DisplayStatus()
    {
        Console.WriteLine($"[{(completed ? 'X' : ' ')}] {goalName} (Eternal) - {goalDescription}");
    }
}