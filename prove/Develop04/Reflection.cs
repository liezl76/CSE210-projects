using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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