using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        //Create videos and add comments
        Video video1 = new Video("G.I Jane", "Demi Moore", 9000);
        video1.AddComment("Luis", "Nice Movie!");
        video1.AddComment("Maria", "Very inspiring!");



        //Display video details
        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}