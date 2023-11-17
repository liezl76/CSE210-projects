using System;
using System.Collections.Generic;

public class EternalGoal : Goal
{
    public EternalGoal(string goalName, int goalType, string description, int points) : base(goalName, goalType, description, points)
    {
    }

    public override void RecordEvent()
    {
        Console.WriteLine("You recorded progress for the eternal goal: " + _goalName);
        completed = true;
    }

    public override bool IsComplete()
    {
        return false;
    }
}