using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Text;

public class Entry
{
    public string _entry;
    public DateTime currentDateTime = DateTime.Now;

    public void EntryDetails()
    {
        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();
        Console.ReadLine();
    }

    public void setEntry(string answer)
    {
        this._entry = answer;
    }

}
