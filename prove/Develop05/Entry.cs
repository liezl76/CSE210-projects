using System;
using System.Collections.Generic;
using System.IO;

class GoalEntry
{
    private List<GoalEntry> entries;
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }
    
    public void GoalEntries()
    {
        entries = new List<GoalEntry>();
    }
    public void AddEntry(GoalEntry entry)
    {
        entries.Add(entry);
    }
}