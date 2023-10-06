using System;
using System.Collections.Generic;
using System.Text;

public class Entry
{
    public string _entry;
    public DateTime date = DateTime.Now;

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