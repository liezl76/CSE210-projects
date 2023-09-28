using System;

public class Entry
{
    public string _entry;
    public DateTime currentDateTime = DateTime.Now;

    public void DisplayCurrentDateTime()
    {
        Console.WriteLine($"{currentDateTime}");
        Console.ReadLine();
    }
    public void acceptDetails()
    {
        Console.Write("\nEntry: ");
        _entry = Console.ReadLine();
    }
}
