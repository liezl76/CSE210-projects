using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Runtime.InteropServices;
using System.Text;

public class Entry
{
    
    public List<Entry> entries = new List<Entry>();

    string[] _questions = {
        "Who was the most interesting person I interacted with today?",
        "Who was the best part of the day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing that I could do over today, what would it be?"
    };
    
    public string _entry;
    public DateTime date = DateTime.Now;
    
    public void PromptQuestion(string questions)
    {        
        Random rnd = new Random();
        int num_question = rnd.Next(0, 4);
        string selected_question = _questions[num_question];
        Console.WriteLine(selected_question);
        string answer = Console.ReadLine();
        entries.Add(new Entry(answer));
    }
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