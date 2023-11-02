using System;

public class BreathingActivity : Activity
{
    private readonly int duration;
    private string _breathInMessage;
    private string _breathOutMessage;
    
    public BreathingActivity(string _activityName, string _description, int _duration, string breathInMessage, string breatOutMessage) : base(activityName, description, duration)
    {
        this._breathInMessage = breathInMessage;
        this._breathOutMessage = breatOutMessage;
    }
    protected override void PerformActivity()
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