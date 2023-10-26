using System;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

public class Activity
{
    private string _description;
    private string _activityName;
    private string _startingMessage;
    private string _endingMessage;
    private DateTime date = DateTime.Now;


    public Activity(string description, string activityName, string startingMessage, string endingMessage)
    {
        _description = description;
        _activityName = activityName;
        _startingMessage = startingMessage;
        _endingMessage = endingMessage;
    }
    public string GetActivity()
    {
        string activity = $"{_activityName}";
        return activity;
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

    public string DisplayEndingMessage()
    {
        string endmessage = $"{_endingMessage}";
        return endmessage;
    }

    public void ShowSpinner()
    {
        
    }

    public void ShowCountdownTimer()
    {

    }

}