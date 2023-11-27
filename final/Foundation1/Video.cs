using System;
using System.Collections.Generic;

public class Video
{
    public string _title { get; set; }
    public string _author { get; set; }
    public int _length { get; set; }
    public List<Comment> comments;

    public Video(string title, string author, int lenght)
    {
        _title = title;
        _author = author;
        _length = lenght;
        comments = new List<Comment>();
    }
    public void AddComment(string commenterName, string commenterTxt)
    {
        Comment comment = new Comment(commenterName, commenterTxt);
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
        Console.WriteLine($"Lenght: {_length} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments: ");
        foreach (var comment in comments)
        {
            Console.WriteLine($"- {comment._commenterName}: {comment._commenterTxt}");
            Console.WriteLine();
        }
    }
}