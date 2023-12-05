using System;
using System.Collections.Generic;

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