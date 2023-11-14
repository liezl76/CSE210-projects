using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _prompt;
    private List<string> _questions;

    public ReflectionActivity(string activityName, string description, int duration, List<string> prompt, List<string> questions)
        : base(description, activityName, duration)
    {
        _prompt = prompt;
        _questions = questions;
    }
    protected override void PerformActivity()
    {
        Random rnd = new Random();
        // Prompt the user to input the duration in seconds
        Console.Write("Enter the duration(in seconds): ");
        int durationInSeconds = Convert.ToInt32(Console.ReadLine());
        // Calculate the duration in milliseconds
        int durationInMilliseconds = durationInSeconds * 1000;
        // Get the start time of the loop
        DateTime startTime = DateTime.Now;
        
        // Continue the loop until the desired duration has elapsed
        while ((DateTime.Now - startTime).TotalSeconds < durationInSeconds)
        {
            string prompt = _prompt[rnd.Next(_prompt.Count)];
            Console.WriteLine($"Prompt: {prompt}");
            Pause(5); // Pause for 5 seconds

            foreach (string question in _questions)
            {
                Console.WriteLine($"Question: {question}");
                Pause(5); // Pause for 5 seconds

                // Check if the desired duration has elapsed
                if ((DateTime.Now - startTime).TotalSeconds >= durationInSeconds)
                {
                    break; // Exit the loop
                }
            }
            // Check if the desired duration has elapsed
            if ((DateTime.Now - startTime).TotalSeconds >= durationInSeconds)
            {
                break; // Exit the loop
            }
        }
    }
}