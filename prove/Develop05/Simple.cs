using System;
using System.Collections.Generic;
using System.ComponentModel;

public class SimpleGoal : Goal
{
    public SimpleGoal(string goalName, string goalDescription, int points) : base(goalName, goalDescription, points)
    {
    }

    public override string Display()
    {
        return $"Simple goal: {goalName}, {goalDescription}, {points}, {(completed ? "Completed" : "Not Completed")}";
    }

    public override void DisplayStatus()
    {
        Console.WriteLine($"[{(completed ? 'X' : ' ')}] {goalName} - {goalDescription}");
    }
}