using System;
using System.Collections.Generic;

class Activity
{
    private DateTime date;
    private int _lengthInMinutes;

    public Activity(DateTime date, int lengthInMinutes)
    {
        this.date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    public virtual double GetDistance()
    {
        return 0; // Default implementation (override in derived classes)
    }

    public virtual double GetSpeed()
    {
        return 0; // Default implementation (override in derived classes)
    }

    public virtual double GetPace()
    {
        return 0; // Default implementation (override in derived classes)
    }

    public string GetSummary()
    {
        return $"{date.ToShortDateString()} - {GetType().Name} ({_lengthInMinutes} min): {GetDistance()} miles, Speed {GetSpeed()} mph, Pace {GetPace()} min per mile";
    }

    public int lengthInMinutes { get { return _lengthInMinutes;} }
}

class Running : Activity
{
    private double distance;

    public Running(DateTime date, int lengthInMinutes, double distance)
        : base(date, lengthInMinutes)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return distance / lengthInMinutes * 60;
    }

    public override double GetPace()
    {
        return lengthInMinutes / distance;
    }
}

class StationaryBicycle : Activity
{
    private double speed;

    public StationaryBicycle(DateTime date, int lengthInMinutes, double speed)
        : base(date, lengthInMinutes)
    {
        this.speed = speed;
    }

    public override double GetDistance()
    {
        return speed * lengthInMinutes / 60;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetPace()
    {
        return 60 / speed;
    }
}

class LapSwimming : Activity
{
    private int laps;

    public LapSwimming(DateTime date, int lengthInMinutes, int laps)
        : base(date, lengthInMinutes)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50 / 1000; // Convert meters to kilometers
    }

    public override double GetSpeed()
    {
        return GetDistance() / lengthInMinutes * 60;
    }

    public override double GetPace()
    {
        return lengthInMinutes / GetDistance();
    }
}
public class Program
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