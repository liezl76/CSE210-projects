using System;
using System.Collections.Generic;

public class OutdoorGathering : Event
{
    private string _weatherStatement;

    public OutdoorGathering(string title, string description, DateTime date, TimeSpan time, Address address, string weatherStatement)
        : base(title, description, date, time, address)
    {
        this._weatherStatement = weatherStatement;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nType: Outdoor Gathering\nWeather: {_weatherStatement}";
    }
}