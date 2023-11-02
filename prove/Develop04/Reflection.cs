using System;

public class ReflectionActivity : Activity
{
    private readonly int duration;
    private List<string> prompts;
    private List<string> questions;
    public ReflectionActivity(string name, string description, int duration, List<string> prompts, List<string> questions)
        : base(name, description, duration)
    {
        this.prompts = prompts;
        this.questions = questions;
    }
    protected override void PerformActivity()
    {
        Random random = new Random();

        for (int i = 0; i < duration; i++)
        {
            string prompt = prompts[random.Next(prompts.Count)];
            Console.WriteLine($"Prompt: {prompt}");
            Pause(2); // Pause for 2 seconds

            foreach (string question in questions)
            {
                Console.WriteLine($"Question: {question}");
                Pause(3); // Pause for 3 seconds
            }
        }
    }
}