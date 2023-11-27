using System;
using System.Collections.Generic;

class Comment
{
    public string _commenterName { get; set; }
    public string _text { get; set; }

    public Comment(string commenterName, string text)
    {
        _commenterName = commenterName;
        _text = text;
    }
}

class Video
{
    public string _title { get; set; }
    public string _author { get; set; }
    public int _length { get; set; }
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        comments = new List<Comment>();
    }

    public void AddComment(string commenterName, string text)
    {
        Comment comment = new Comment(commenterName, text);
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
        Console.WriteLine($"Length: {_length} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            Console.WriteLine($"- {comment._commenterName}: {comment._text}");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();

        // Create videos and add comments
        Video video1 = new Video("C# Basics", "John Doe", 300);
        video1.AddComment("Alice", "Nice tutorial!");
        video1.AddComment("Bob", "Very helpful, thanks!");

        Video video2 = new Video("Object-Oriented Programming", "Jane Smith", 500);
        video2.AddComment("Charlie", "Great explanation!");
        video2.AddComment("David", "Could you cover polymorphism in the next video?");

        Video video3 = new Video("ASP.NET Core", "Mary Johnson", 400);
        video3.AddComment("Eve", "Awesome content!");
        video3.AddComment("Frank", "I learned a lot, thank you!");

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Display video details
        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}
