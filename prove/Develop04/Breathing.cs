using System;
using System.Collections.Generic;
using System.Threading;

public class BreathingActivity : Activity
{
    //private const int AnimationDuration = 1000; // Animation duration in milliseconds

    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void PerformActivity()
    {
        Console.Write("Enter the duration (in seconds): ");
        _duration = Convert.ToInt32(Console.ReadLine());

        int cycles = _duration / 2; // Each cycle includes a breath in and a breath out

        for (int i = 0; i < cycles; i++)
        {
            Console.WriteLine("Breathing in...");
            AnimateSpinner();
            Console.WriteLine();

            Console.WriteLine("Breathing out...");
            AnimateSpinner();
            Console.WriteLine();
        }
    }
    private void AnimateSpinner()
    {
        char[] spinner = { '|', '/', '-', '\\' };

        for (int i = 0; i < 5; i++)
        {
            Console.Write(spinner[i % 4] + " ");
            Thread.Sleep(1000); // Pause for 1 second
            Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
        }

        Console.WriteLine();
    }
}