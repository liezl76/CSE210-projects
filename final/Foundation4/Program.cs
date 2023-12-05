using System;

class Program
{
    static void Main(string[] args)
    {
        // Create activities
        Running runningActivity = new Running(new DateTime(2022, 11, 3), 30, 3.0);
        StationaryBicycle bicycleActivity = new StationaryBicycle(new DateTime(2022, 11, 5), 30, 20.0);
        LapSwimming swimmingActivity = new LapSwimming(new DateTime(2022, 11, 10), 30, 10);

        // Display summary for each activity
        Console.WriteLine(runningActivity.GetSummary());
        Console.WriteLine(bicycleActivity.GetSummary());
        Console.WriteLine(swimmingActivity.GetSummary());
    }
}