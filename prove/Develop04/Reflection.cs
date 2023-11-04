using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _prompt;
    private List<string> _questions;
    private DateTime startTime;

    public ReflectionActivity(string activityName, string description, int duration, List<string> prompt, List<string> questions)
        : base(description, activityName, duration)
    {
        _prompt = prompt;
        _questions = questions;
    }
    protected override void PerformActivity()
    {
    Random rnd = new Random();

    for (int i = 0; i < _duration; i++)
        {
            string prompt = _prompt[rnd.Next(_prompt.Count)];
            Console.WriteLine($"Prompt: {prompt}");
            Pause(5); // Pause for 5 seconds

            foreach (string question in _questions)
            {
                Console.WriteLine($"Question: {question}");
                Pause(5); // Pause for 5 seconds
            }
        }
    }
}