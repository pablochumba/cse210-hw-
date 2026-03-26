using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>
        {
            new Video("How to Build a Budget Gaming PC", "TechForge", 845),
            new Video("5 Easy Pasta Recipes for Weeknights", "Home Kitchen Lab", 612),
            new Video("Top 10 Hidden Beaches in Chile", "TravelScope", 734),
            new Video("Beginner Guitar Chords in 15 Minutes", "String Start", 903)
        };

        videos[0].AddComment(new Comment("Alex", "This parts list was really helpful."));
        videos[0].AddComment(new Comment("Mia", "Can you do a 2026 version next?"));
        videos[0].AddComment(new Comment("Jordan", "The cable management tips were great."));

        videos[1].AddComment(new Comment("Sofia", "I tried recipe number three and loved it."));
        videos[1].AddComment(new Comment("Daniel", "Clear instructions and good pacing."));
        videos[1].AddComment(new Comment("Emma", "Please make a vegetarian version."));

        videos[2].AddComment(new Comment("Chris", "Now I want to plan a trip immediately."));
        videos[2].AddComment(new Comment("Valentina", "The drone shots were amazing."));
        videos[2].AddComment(new Comment("Noah", "I had never heard of two of these places."));

        videos[3].AddComment(new Comment("Liam", "Finally a lesson that makes sense."));
        videos[3].AddComment(new Comment("Camila", "The slow practice section was useful."));
        videos[3].AddComment(new Comment("Ethan", "A strumming lesson would be a good follow-up."));

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length (seconds): {video.LengthInSeconds}");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}
