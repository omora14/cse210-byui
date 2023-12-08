using System;
//1
class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("HTML & Coding Introduction - Course for Beginners", "freeCodeCamp.org", 7445);
        video1.AddComment("ZeryuGames", "This is awesome! Each item crystal cear. Thanks a lot for your effort doing this course.");
        video1.AddComment("hdmaragh", "These 2 hours are worth and entire semester long course og most university in this subject... very well done");
        video1.AddComment("mitchellbrown1634", "This was amazing. Thank you much Aria");
        videos.Add(video1);

        Video video2 = new Video("How to Program in C#", "Brackeys", 111);
        video2.AddComment("mr1tbofram", "I'm so glad we have tutorials like this.");
        video2.AddComment("marcofilho", "PLEEEEAASE, keep the series up! Your tutorials are simply the best available for free, even better than some paid ones.");
        video2.AddComment("necex", "Fast, easy and fun tutorials. Absolutely amazing");
        videos.Add(video2);

        Video video3 = new Video("C# polymorphism", "Bro Code", 310);
        video3.AddComment("videolosss", "Again! Describing difficult concepts so simply. You got the gift");
        video3.AddComment("MrJeeosoft", "Excellent example as well as simple, thank you for sharing");
        video3.AddComment("SleepyShores", "Thanks! Explained clearly! But you missed it further into compile-time and run-time polymorphism?");
        video3.AddComment("ilakutemmanuel9688", "The best explanation of polymorphism I have ever come across, Thank you");
        videos.Add(video3);

        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._length} seconds");
            Console.WriteLine($"Number of comments: {video.numberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.sendComments())
            {
                Console.WriteLine($"- {comment._userName}: {comment._text}");
            }
            Console.WriteLine();
        }
    }
}