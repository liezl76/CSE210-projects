using System;
using System.Xml.Schema;

public class Reference
{
    private int _beginVerse;
    private int _endVerse;
    private string _book;
    private int _chapter;

    public Reference()
    {
        _book = "James";
        _chapter = 1;
        _beginVerse = 5;
        _endVerse = 6;
    }
    public string GetBookString()
    {
        string book = $"{_book} {_chapter}:{_beginVerse}-{_endVerse}";
        return book;
    }
}