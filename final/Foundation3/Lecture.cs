using System;
using System.Collections.Generic;

public class Lecture : Event
{
    private string _speaker;
    private int _capacity;

    public Lecture(string title, string description, DateTime date, TimeSpan time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this._speaker = speaker;
        this._capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nType: Lecture\nSpeaker: {_speaker}\nCapacity: {_capacity}";
    }
}