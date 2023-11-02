using System;
using System.Collections.Generic;

public class Activity
{
    private string _description;
    private string _activityName;
    private int _duration;
    public Activity(string description, string activityName, int duration)
    {
        this._description = description;
        this._activityName = activityName;
        this._duration = duration;
    }
    public void Start()
    {
        //Starting message
        Console.WriteLine($"Starting {_activityName} activity...");
        Console.WriteLine(_description);
        Console.WriteLine($"Duration: {_duration} seconds");

        //Pause for several seconds before finishing
        Pause(3);

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
            System.Threading.Thread.Sleep(3000); //Pause for 3 seconds
        }
        Console.WriteLine();
    }
}