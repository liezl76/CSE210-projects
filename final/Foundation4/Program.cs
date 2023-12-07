using System;

class Program
{
    static void Main(string[] args)
    {
        // Create activities
        Running runningActivity = new Running(new DateTime(2023, 11, 6), 30, 3.0);
        StationaryBicycle bicycleActivity = new StationaryBicycle(new DateTime(2023, 11, 8), 30, 20.0);
        LapSwimming swimmingActivity = new LapSwimming(new DateTime(2023, 11, 10), 240, 5);

        // Display summary for each activity
        Console.WriteLine();
        Console.WriteLine(runningActivity.GetSummary());
        Console.WriteLine(bicycleActivity.GetSummary());
        Console.WriteLine(swimmingActivity.GetSummary());
        Console.WriteLine();
    }
}