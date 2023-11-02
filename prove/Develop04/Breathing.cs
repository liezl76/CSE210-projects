using System;
using System.Reflection.Metadata;

public class BreathingActivity : Activity
{
    private string _breathInMessage;
    private string _breathOutMessage;
    
    public BreathingActivity(string _activityName, string _description, int _duration, string breathInMessage, string breatOutMessage) : base(activityname, description, duration)
    {
        this._breathInMessage = breathInMessage;
        this._breathOutMessage = breatOutMessage;
    }
    protected override void PerformActivity(int duration)
    {
        for (int i=0; i < duration; i++)
        {
            Console.WriteLine(_breathInMessage);
            Pause(2); 

            Console.WriteLine(_breathOutMessage);
            Pause(2);
        }
    }
}