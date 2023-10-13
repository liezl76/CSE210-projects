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
        _book = "Proverbs";
        _chapter = 3;
        _beginVerse = 3;
        _endVerse = 4;
    }

    public string GetBook()
    {
        string book = $"{_book} {_chapter}:{_beginVerse}-{_endVerse}";
        return book;
    }
}