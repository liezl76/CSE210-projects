using System;
using System.Collections.Generic;

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