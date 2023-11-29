using System;
using System.Collections.Generic;

public class Video
{
    public string _title { get; set; }
    public string _author { get; set; }
    public int _lengthSec { get; set; }
    public List<Comment> comments;

    public Video(string title, string author, int lengthSec)
    {
        _title = title;
        _author = author;
        _lengthSec = lengthSec;
        comments = new List<Comment>();
    }

    public void AddComment(string commenterName, string commentertext)
    {
        Comment comment = new Comment(commenterName, commentertext);
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public void DisplayVideoDetails()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_lengthSec} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");
        
        foreach (var comment in comments)
        {
            Console.WriteLine($"- {comment._commenterName}: {comment._commentertext}");
        }
        Console.WriteLine();
    }
}