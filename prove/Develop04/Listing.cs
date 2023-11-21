using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _items;

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        _items = new List<string>();
    }
    protected override void PerformActivity()
    {
        Console.Write("Enter the duration (in seconds): ");
        _duration = Convert.ToInt32(Console.ReadLine());

        Random random = new Random();

        int elapsedTime = 0;

        while (elapsedTime < _duration)
        {
            string prompt = _prompts[random.Next(_prompts.Count)];
            Console.WriteLine($"Prompt: {prompt}");
            AnimateSpinner();
            elapsedTime += 2;

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
            AnimateSpinner();
            elapsedTime += 2;
        }
    }
    private void AnimateSpinner()
    {
        char[] spinner = { '|', '/', '-', '\\' };

        for (int i = 0; i < 10; i++)
        {
            Console.Write(spinner[i % 4] + " ");
            Thread.Sleep(1000); // Pause for 1 seconds
            Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
        }
        Console.WriteLine();
    }
}