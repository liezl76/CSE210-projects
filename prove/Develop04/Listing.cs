using System;

public class ListingActivity : Activity
{
    private List<string> prompts;
    private List<string> items;

    public ListingActivity(string name, string description, int duration, List<string> prompts, List<string> items)
        : base(name, description, duration)
    {
        this.prompts = prompts;
        this.items = items;
    }
    public int duration { get; private set; }
    protected override void PerformActivity()
    {
        Random random = new Random();

        for (int i = 0; i < duration; i++)
        {
            string prompt = prompts[random.Next(prompts.Count)];
            Console.WriteLine($"Prompt: {prompt}");
            Pause(2); // Pause for 2 seconds

            Console.WriteLine("Start Listing Items:");

            int count = 0;
            while (true)
            {
                string item = Console.ReadLine();
                if (string.IsNullOrEmpty(item))
                    break;

                items.Add(item);
                count++;
            }

            Console.WriteLine($"Total items listed: {count}");
            Pause(2); // Pause for 2 seconds
        }
    }
}