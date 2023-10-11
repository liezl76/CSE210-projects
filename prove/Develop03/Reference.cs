using System;
using System.Xml.Schema;

public class Reference
{
    private int _beginVerse;
    private int _endVerse;
    private string _book;

    public int _BeginVerse
    {
        get {return _beginVerse;}
        set {_beginVerse = value;}
    }

    public int _EndVerse
    {
        get {return _endVerse;}
        set {_endVerse = value;}
    }
    public string _Book
    {
        get {return _book;}
        set {_book = value;}
    }

}