using System;
using System.Collections.Generic;

public abstract class Goal
{
    protected string _goalName;
    protected string _type;
    protected int _value;
    protected bool _completed;

    public Goal(string goalName, string type, int value)
    {
        _goalName = goalName;
        _type = type;
        _value = value;
        _completed = false;
    }
    public void CreateGoal()
    {
        Console.Clear();
        Console.WriteLine("Select a choice from the menu: ");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        string typeChoice = Console.ReadLine();
        int value = 0;
        int targetTimes = 0;
        int bonus = 0;

        switch (typeChoice)
        {
            case "1":
                
                break;
            case "2":

                break;
            case "3":

                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }
    public abstract void RecordEvent();
    public void markCompleted()
    {
        _completed = true;
    }
    public bool IsCompleted()
    {
        return _completed;
    }
    public override string ToString()
    {
        return "Name:" + _goalName + ", Type: " + _type + ", Value: " + _value + ", Completed: " + _completed;
    }
}