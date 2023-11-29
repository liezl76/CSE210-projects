using System;

public class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Create videos and add comments
        Video video1 = new Video("If I were You, What Would I Do", "BYU Speeches", 1342);
        video1.AddComment("Betty", "I love this man");
        video1.AddComment("Bobby", "Very inspiring!");

        Video video2 = new Video("JavaScript Tutorial _12", "SDPT", 810);
        video2.AddComment("Charlie", "Great explanation!");
        video2.AddComment("David", "Easy to understand?");

        Video video3 = new Video("JavaScript Tutorial _13", "SDPT", 850);
        video3.AddComment("Stella", "Awesome content!");
        video3.AddComment("Luis", "I learned a lot, thank you!");

        Video video4 = new Video("Career Boost with Power BI", "Exodus experts", 7440);
        video4.AddComment("Lauren", "Great Tutorials!");
        video4.AddComment("Kuen", "Thank you for the additional knowledge you imparted.");
        
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        // Display video details
        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}