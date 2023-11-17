using System;
using System.Collections.Generic;

public class SimpleGoal : Goal
{
    public SimpleGoal(string goalName, int goalType, string description, int points) : base(goalName, goalType, description, points)
    {
    }

    public override int RecordEvent()
    {
        completed = true;
        return 0;
    }

    public override bool IsComplete()
    {
        return true;
    }
}