using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    protected string _description;
    protected string _activityName;
    protected int _duration;

    public Activity(string activityName, string description)
    {
        _activityName = activityName;
        _description = description;
    }

    public void Start()
    {
        DisplayStartingMessage();
        PerformActivity();
        DisplayEndingMessage();
    }

    protected void DisplayStartingMessage()
    {
        Console.WriteLine($"Starting {_activityName} activity...");
        Console.WriteLine(_description);
        Console.WriteLine("Prepare to begin....\n");
        Pause(2);
    }

    protected virtual void PerformActivity()
    {
        // Default implementation, to be overridden by derived classes
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine("\nGood job!");
        Console.WriteLine($"You have completed the {_activityName} activity.");
        Console.WriteLine($"Total duration: {_duration} seconds\n");
        Pause(3);
    }

    protected void Pause(int seconds)
    {
        Console.WriteLine("Pausing...");
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine(i);
            System.Threading.Thread.Sleep(2000); // Pause for 2 second
        }
        Console.WriteLine();
    }
}