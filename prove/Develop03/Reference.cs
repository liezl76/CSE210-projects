using System;
using System.Xml.Schema;

public class Reference
{
    private int _beginVerse;
    private int _endVerse;
    private string _book;
    private int _chapter;
    private int _verse;

    public Reference()
    {
        _book = "James";
        _chapter = 2;
        _beginVerse = 17;
        _endVerse = 18;
    }
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    public string GetReferenceString()
    {
        string reference = $"{_book} {_chapter}:{_verse}";
        return reference;
    }
}