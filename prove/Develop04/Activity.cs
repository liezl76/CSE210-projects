using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    private string _description;
    private string _activityName;
    protected int _duration;
    public Activity(string description, string activityName, int duration)
    {
        _description = description;
        _activityName = activityName;
        _duration = duration;
    }
    public void Start()
    {
        //Starting message
        Console.WriteLine($"Starting {_activityName} activity...");
        Console.WriteLine(_description);
        Console.WriteLine("Prepare to begin....\n");

        //Pause for several seconds before finishing
        Pause(2);

        // Specific activity behavior implemented in derived classes
        PerformActivity();

        // Common ending message
        Console.WriteLine("\nGood job!");
        Console.WriteLine($"You have completed the {_activityName} activity.");
        Console.WriteLine($"Total duration: {_duration} seconds\n");

        // Pause for several seconds before finishing
        Pause(3);
    }
    protected virtual void PerformActivity()
    {
        //This method will be overridden in derived classess
    }
    protected void Pause(int seconds)
    {
        Console.WriteLine("Pausing...");
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine(i);
            System.Threading.Thread.Sleep(2000); //Pause for 2 seconds
        }
        Console.WriteLine();
    }
}