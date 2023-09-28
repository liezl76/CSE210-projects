using System;

public class Entry
{
    public DateTime currentDateTime = DateTime.Now;
 
    public void DisplaycurrentDateTime()
    {
        Console.WriteLine($"{currentDateTime}");
        Console.ReadLine();
    }
    
}
