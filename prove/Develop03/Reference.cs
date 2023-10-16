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
        _book = "Philippians";
        _chapter = 4;
        _beginVerse = 13;
    }
    public string GetBookString()
    {
        string book = $"{_book} {_chapter}:{_beginVerse}";
        return book;
    }
}