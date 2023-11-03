using System;

public class BreathingActivity : Activity
{
    private string _breathInMessage;
    private string _breathOutMessage;
    public BreathingActivity(string activityName, string description, int duration, string breathInMessage, string breathOutMessage) 
    : base(description, activityName, duration)
    {
        _breathInMessage = breathInMessage;
        _breathOutMessage = breathOutMessage;
    }
    protected override void PerformActivity()
    {
        // Prompt the user to input the duration in seconds
        Console.Write("Enter the duration: ");
        int durationInSeconds = Convert.ToInt32(Console.ReadLine());
        // Calculate the duration in milliseconds
        int durationInMilliseconds = durationInSeconds * 1000;
        // Get the start time of the loop
        DateTime startTime = DateTime.Now;
        
        // Continue the loop until the desired duration has elapsed
        while (DateTime.Now - startTime < TimeSpan.FromMilliseconds(durationInMilliseconds))
        {
            Console.WriteLine(_breathInMessage);
            Pause(2);
            
            Console.WriteLine(_breathOutMessage);
            Pause(2);
        }
    }
}