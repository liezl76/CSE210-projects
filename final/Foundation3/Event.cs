using System;
using System.Collections.Generic;

public class Event
{
    private string _title;
    private string _description;
    private DateTime date;
    private TimeSpan time;
    private Address _address;

    public Event(string title, string description, DateTime date, TimeSpan time, Address address)
    {
        _title = title;
        _description = description;
        this.date = date;
        this.time = time;
        _address = address;
    }

    public string GetStandardDetails()
    {
        return $"Event: {_title}\nDescription: {_description}\nDate: {date.ToShortDateString()}\nTime: {time.ToString(@"hh\:mm")}\nAddress: {_address.GetFullAddress()}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public string GetShortDescription()
    {
        return $"Type: {GetType().Name}\nTitle: {_title}\nDate: {date.ToShortDateString()}";
    }
}
