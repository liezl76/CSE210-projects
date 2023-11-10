using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Scoreboard scoreboard = new Scoreboard();

        SimpleGoal simpleGoal = new SimpleGoal("Simple Goal", "Simple", 100, 10);
        EternalGoal eternalGoal = new EternalGoal("Eternal Goal", "Eternal", 200, 5);
        ChecklistGoal checklistGoal = new ChecklistGoal("Checllist Goal", "Checklist", 300, 3);

        scoreboard.AddGoal(simpleGoal);
        scoreboard.AddGoal(eternalGoal);
        scoreboard.AddGoal(checklistGoal);

        scoreboard.RecordEvent("Simple Goal");
        scoreboard.RecordEvent("Eternal Goal");
        scoreboard.RecordEvent("Checklist Goal");
        scoreboard.RecordEvent("Checklist Goal");
        scoreboard.RecordEvent("Checklist Goal");

        scoreboard.DisplayGoals();
        scoreboard.DisplayScore();
        
    }
}