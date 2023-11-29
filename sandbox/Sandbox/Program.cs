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

public class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, DateTime date, TimeSpan time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nType: Lecture\nSpeaker: {speaker}\nCapacity: {capacity}";
    }
}

public class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, DateTime date, TimeSpan time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nType: Reception\nRSVP Email: {rsvpEmail}";
    }
}

public class OutdoorGathering : Event
{
    private string weatherStatement;

    public OutdoorGathering(string title, string description, DateTime date, TimeSpan time, Address address, string weatherStatement)
        : base(title, description, date, time, address)
    {
        this.weatherStatement = weatherStatement;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nType: Outdoor Gathering\nWeather: {weatherStatement}";
    }
}

public class Address
{
    private string _streetAddress;
    private string _city;
    private string _stateProvince;
    private string _country;

    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }

    public string GetFullAddress()
    {
        return $"{_streetAddress}, {_city}, {_stateProvince}, {_country}";
    }
}

public class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address address1 = new Address("127 Ongpin St", "Manila", "MNL", "Phillippines");
        Address address2 = new Address("Jose Rizal St", "Quezon", "MNL", "Phillippines");
        Address address3 = new Address("Tan Tock Seng St", "Singapore", "SG", "Singapore");

        // Create events
        Event event1 = new Event("Tech Talk", "Career Boost With Power BI", new DateTime(2023, 12, 1), new TimeSpan(18, 30, 0), address1);
        Lecture lecture1 = new Lecture("Cloud Computing Workshop", "AwSome Day Conference", new DateTime(2023, 11, 16), new TimeSpan(15, 0, 0), address2, "Dr. Smith", 50);
        Reception reception1 = new Reception("Networking Night", "Connect with IT professionals", new DateTime(2023, 12, 10), new TimeSpan(19, 0, 0), address3, "rsvp@example.com");
        OutdoorGathering gathering1 = new OutdoorGathering("A Day with the Techy", "Enjoy a Tech Day", new DateTime(2023, 12, 15), new TimeSpan(12, 0, 0), address1, "Sunny skies expected");

        // Display marketing messages
        Console.WriteLine("\nEvent 1 Marketing Messages:");
        Console.WriteLine(event1.GetStandardDetails());
        Console.WriteLine(event1.GetFullDetails());
        Console.WriteLine(event1.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine("Lecture 1 Marketing Messages:");
        Console.WriteLine(lecture1.GetStandardDetails());
        Console.WriteLine(lecture1.GetFullDetails());
        Console.WriteLine(lecture1.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine("Reception 1 Marketing Messages:");
        Console.WriteLine(reception1.GetStandardDetails());
        Console.WriteLine(reception1.GetFullDetails());
        Console.WriteLine(reception1.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine("Outdoor Gathering 1 Marketing Messages:");
        Console.WriteLine(gathering1.GetStandardDetails());
        Console.WriteLine(gathering1.GetFullDetails());
        Console.WriteLine(gathering1.GetShortDescription());
        Console.WriteLine();
    }
}