using System;
using System.Collections.Generic;
using System.IO;

public class Entry
{
    public string _prompt {get; set;}
    public string _response {get; set;}
    public string _location {get; set;}
    public string _date {get; set;}

    public Entry(string prompt, string response, string location, string date)
    {
        _prompt = prompt;
        _response = response;
        _location = location;
        _date = date;
    }
}
