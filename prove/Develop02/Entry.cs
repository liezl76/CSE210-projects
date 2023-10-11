using System;
using System.Collections.Generic;
using System.Text;

public class Entry
{
    private string _entry;
    private DateTime date = DateTime.Now;

    public Entry(string answer)
    {
        this._entry = answer;
    }

    public DateTime getDateTime()//method to get date
    {
       return this.date;
    }
    public string getEntry()//method to get entry
    {
        return this._entry;
    }
}