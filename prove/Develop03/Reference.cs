using System;
using System.Xml.Schema;

public class Reference
{
    private int _beginVerse;
    private int _endVerse;
    private string _book;
    private int _chapter;
    private int _singleVerse;

    public Reference()
    {
        _book = "James";
        _chapter = 2;
        _beginVerse = 17;
        _endVerse = 18;
    }
    public Reference(string book, int chapter, int singleVerse)
    {
        _book = book;
        _chapter = chapter;
        _singleVerse = singleVerse;
    }

    public string GetReferenceString()
    {
        string book = $"{_book} {_chapter}:{_beginVerse}-{_endVerse}";
        return book;
    }
}