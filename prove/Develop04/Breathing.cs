using System;

public class BreathingActivity : Activity
{
    private string _breathInMessage;
    private string _breathOutMessage;
    
    public BreathingActivity(string activityName, string description, int duration, string breathInMessage, string breatOutMessage) : base(description, activityName, duration)
    {
        this._breathInMessage = breathInMessage;
        this._breathOutMessage = breatOutMessage;
    }
    public int duration { get; private set; }
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