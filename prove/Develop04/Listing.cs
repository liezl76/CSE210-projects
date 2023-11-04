using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _items;

    public ListingActivity(string activityName, string description, int duration, List<string> prompts, List<string> items)
        : base(description, activityName, duration)
    {
        _prompts = prompts;
        _items = items;
    }
    protected override void PerformActivity()
    {
        Random random = new Random();

        // Prompt the user to input the duration in seconds
        Console.Write("Enter the duration(in seconds): ");
        int durationInSeconds = Convert.ToInt32(Console.ReadLine());
        // Calculate the duration in milliseconds
        int durationInMilliseconds = durationInSeconds * 1000;
        // Get the start time of the loop
        DateTime startTime = DateTime.Now;
        // Continue the loop until the desired duration has elapsed
        while (DateTime.Now - startTime < TimeSpan.FromMilliseconds(durationInMilliseconds))

        for (int i = 0; i < _duration; i++)
        {
            string prompts = _prompts[random.Next(_prompts.Count)];
            Console.WriteLine($"Prompt: {prompts}");
            Pause(2); // Pause for 2 seconds

            Console.WriteLine("Start Listing Items:");

            int count = 0;
            while (true)
            {
                string item = Console.ReadLine();
                if (string.IsNullOrEmpty(item))
                {
                    break; // Exit the loop when an empty string is entered
                }

                _items.Add(item);
                count++;
            }
            Console.WriteLine($"Total items listed: {count}");
            Pause(2); // Pause for 2 seconds
        }
    }
}