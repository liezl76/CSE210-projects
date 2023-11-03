using System;

public class ReflectionActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    public ReflectionActivity(string activityName, string description, int duration, List<string> prompts, List<string> questions)
        : base(description, activityName, duration)
    {
        _prompts = prompts;
        _questions = questions;
    }
    protected override void PerformActivity()
    {
        Random random = new Random();

        for (int i = 0; i < _duration; i++)
        {
            string prompt = _prompts[random.Next(_prompts.Count)];
            Console.WriteLine($"Prompt: {prompt}");
            Pause(2); // Pause for 2 seconds

            foreach (string question in _questions)
            {
                Console.WriteLine($"Question: {question}");
                Pause(3); // Pause for 3 seconds
            }
        }
    }
}