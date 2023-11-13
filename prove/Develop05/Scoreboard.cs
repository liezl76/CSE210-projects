using System;
using System.Collections.Generic;
public class Scoreboard
{
    private List<Goal> goals;
    private int totalScore;

    public Scoreboard()
    {
        goals = new List<Goal>();
        totalScore = 0;
    }
    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }
    public void RecordEvent(string goalName)
    {
        foreach (Goal goal in goals)
        {
            if (goal._name == goalName)
            {
                goal.RecordEvent();
                break;
            }
        }
    }
    public void DisplayGoals()
    {
        foreach (Goal goal in goals)
        {
            Console.WriteLine(goal._name);
        }
    }
    public void SaveGoals()
    {
        //Code to save goals to a file
        Console.WriteLine("Saving the file...");
        string file = "Goals.txt";

        using (StreamWriter writer = new StreamWriter(file))
        {
            writer.WriteLine();
            writer.WriteLine();
            writer.WriteLine();
        }
    }
    public void LoadGoals()
    {
        //Code to load goals to a file
    }
    public void DisplayScore()
    {
        foreach (Goal goal in goals)
        {
            Console.WriteLine(totalScore);
        }
    }
}