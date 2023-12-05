using System;

class Program
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