using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Runtime.InteropServices;
using System.Text;

public class Entry
{
    public string _entry;
    public DateTime date = DateTime.Now;

    public Entry(string answer)
    {
         this._entry = answer;
    }

    public DateTime getDateTime()
    {
       return this.date;
    }

    public string getEntry()
    {
        return this._entry;
    }
    
}
