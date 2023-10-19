using System;
using System.Xml.Schema;

public class Reference
{
    //Private Attributes / Fields
    private int _beginVerse;
    private int _endVerse;
    private string _book;
    private int _chapter;
    private int _verse;

    //Properties
    public Reference(string book, int chapter, int beginVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _beginVerse = beginVerse;
        _endVerse = endVerse;
    }
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }
    //Constructors
    public string GetReferenceVerse()
    {
        string reference1 = $"{_book} {_chapter}:{_verse}";
        return reference1;
    }
    public string GetReferenceVerse2()
    {
        string reference = $"{_book} {_chapter}:{_beginVerse}-{_endVerse}";
        return reference;
    }
}