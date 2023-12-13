using System;
//4
class Program
{
    static void Main(string[] args)
    {
        var activities = new Activity[]
{
            new Running(new DateTime(2023, 11, 3), 30, 4.8, "Running"),
            new Cycling(new DateTime(2023, 11, 4), 30, 5, "Cycling"),
            new Swimming(new DateTime(2023, 11, 5), 50, 1, "Swimming"),
};

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.summary());
        }
    }
}