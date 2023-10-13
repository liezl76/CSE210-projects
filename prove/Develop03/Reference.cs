using System;
using System.Xml.Schema;

public class Reference
{
    private int _beginVerse;
    private int _endVerse;
    private string _book;
    private int _chapter;

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
    public int _Chapter
    {
        get {return _chapter;}
        set {_chapter = value;}
    }

    public string GetBook()
    {
        string book = $"{_book}";
        return book;
    }
    public string GetChapterVerseString()
    {
        string chapterVerse = $"{_chapter} {_beginVerse}:{_endVerse}";
        return chapterVerse;
    }
}