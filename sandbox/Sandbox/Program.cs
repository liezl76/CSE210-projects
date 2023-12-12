using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    protected string _description;
    protected string _activityName;
    protected int _duration;

    public Activity(string activityName, string description)
    {
        _activityName = activityName;
        _description = description;
    }

    public void Start()
    {
        DisplayStartingMessage();
        PerformActivity();
        DisplayEndingMessage();
    }

    protected void DisplayStartingMessage()
    {
        Console.WriteLine($"Starting {_activityName} activity...");
        Console.WriteLine(_description);
        Console.WriteLine("Prepare to begin....\n");
        Pause(2);
    }

    protected virtual void PerformActivity()
    {
        // Implementation, to be overridden by derived classes
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine("\nGood job!");
        Console.WriteLine($"You have completed the {_activityName} activity.");
        Console.WriteLine($"Total duration: {_duration} seconds\n");
        Pause(3);
    }

    protected void Pause(int seconds)
    {
        Console.WriteLine("Pausing...");
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine(i);
            System.Threading.Thread.Sleep(2000); // Pause for 2 second
        }
        Console.WriteLine();
    }
}

public class BreathingActivity : Activity
{
    private const int AnimationDuration = 1000; // Animation duration in milliseconds

    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void PerformActivity()
    {
        Console.Write("Enter the duration (in seconds): ");
        _duration = Convert.ToInt32(Console.ReadLine());

        int cycles = _duration / 2; // Cycle includes a breath in and a breath out

        for (int i = 0; i < cycles; i++)
        {
            Console.WriteLine("Breathing in...");
            AnimateBreath();
            Pause(1); // Pause for 1 second

            Console.WriteLine("Breathing out...");
            AnimateBreath();
            Pause(1); // Pause for 1 second
        }
    }

    private void AnimateBreath()
    {
        Console.Write("[");

        // Breathing in/out animation
        for (int i = 0; i < 15; i++)
        {
            Console.Write("=");
            Thread.Sleep(AnimationDuration / 15);
        }

        Console.WriteLine("]");
    }
}

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

        DateTime startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            Random random = new Random();
            string prompt = _prompts[random.Next(_prompts.Count)];
            Console.WriteLine($"Prompt: {prompt}");
            AnimateBouncingBall();

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
        }
        Console.WriteLine("Activity completed!");
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

public class ReflectionActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }
    protected override void PerformActivity()
    {
        Console.Write("Enter the duration (in seconds): ");
        _duration = Convert.ToInt32(Console.ReadLine());

        Random rnd = new Random();

        int elapsedTime = 0;

        while (elapsedTime < _duration)
        {
            string prompt = _prompts[rnd.Next(_prompts.Count)];
            Console.WriteLine($"Prompt: {prompt}");
            AnimateSpinner();
            elapsedTime += 5;

            foreach (string question in _questions)
            {
                Console.WriteLine($"Question: {question}");
                AnimateSpinner();
                elapsedTime += 5;

                if (elapsedTime >= _duration)
                    break;
            }
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

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine();
        DisplayWelcomeMessage();

        bool exitProgram = false;
        while (!exitProgram)
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit\n");
            Console.WriteLine("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    new BreathingActivity().Start();
                    break;
                case "2":
                    Console.Clear();
                    new ReflectionActivity().Start();
                    break;
                case "3":
                    Console.Clear();
                    new ListingActivity().Start();
                    break;
                case "4":
                    exitProgram = true;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice. Please try again.\n");
                    break;
            }
            if (!exitProgram)
            {
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
            }
        }
    }
    public static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the Mindfulness Program!");
    }
}


