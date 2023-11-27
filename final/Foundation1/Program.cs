using System;

public class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Create videos and add comments
        Video video1 = new Video("If I were You, What Would I Do", "BYU Speeches", 1342);
        video1.AddComment("Alice", "I love this man");
        video1.AddComment("Bob", "Very inspiring!");

        Video video2 = new Video("JavaScript Tutorial _12", "SDPT", 810);
        video2.AddComment("Charlie", "Great explanation!");
        video2.AddComment("David", "Easy to understand?");

        Video video3 = new Video("JavaScript Tutorial _13", "SDPT", 850);
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