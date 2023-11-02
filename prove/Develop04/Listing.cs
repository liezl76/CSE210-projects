using System;

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

        for (int i = 0; i < _duration; i++)
        {
            string prompt = _prompts[random.Next(_prompts.Count)];
            Console.WriteLine($"Prompt: {prompt}");
            Pause(2); // Pause for 2 seconds

            Console.WriteLine("Start Listing Items:");

            int count = 0;
            while (true)
            {
                string item = Console.ReadLine();
                if (string.IsNullOrEmpty(item))
                    break;

                _items.Add(item);
                count++;
            }

            Console.WriteLine($"Total items listed: {count}");
            Pause(2); // Pause for 2 seconds
        }
    }
}