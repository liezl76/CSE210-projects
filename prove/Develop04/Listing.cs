using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _items;

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
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
            AnimateBouncingBall();
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
            AnimateBouncingBall();
            elapsedTime += 2;
        }
    }
    private void AnimateBouncingBall()
    {
        int left = Console.CursorLeft;
        int top = Console.CursorTop;

        for (int i = 0; i < 5; i++)
        {
            Console.Write("O");
            Thread.Sleep(1000); // Pause for 1 second
            Console.SetCursorPosition(left, top);
            Console.Write(" ");
            Console.SetCursorPosition(left, top);
            Thread.Sleep(1000); // Pause for 1 second
        }
        Console.WriteLine();
    }
}