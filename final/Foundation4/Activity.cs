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