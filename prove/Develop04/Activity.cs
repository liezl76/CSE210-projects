using System;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
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
        Console.WriteLine($"Starting {activityName} activity...");
        Console.WriteLine(description);
        Console.WriteLine($"Duration: {duration} seconds");

    }
    public string GetDescription()
    {
        string description = $"{_description}";
        return description;
    }
    public string DisplayStartingMessage()
    {
        string startmessage = $"{_startingMessage}";
        return startmessage;
    }
    public void ShowSpinner()
    {
        
    }
    public void ShowCountdownTimer()
    {

    }

}