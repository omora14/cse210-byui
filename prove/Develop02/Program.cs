using System;
using System.Collections.Generic;
using System.IO;

public abstract class JournalEntry
{
    public DateTime Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    public abstract void Display();
}

public class DailyPromptJournalEntry : JournalEntry
{
    public override void Display()
    {
        Console.WriteLine($"Date: {Date.ToShortDateString()}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}");
        Console.WriteLine();
    }
}

public class Journal
{
    private List<JournalEntry> entries;

    public Journal()
    {
        entries = new List<JournalEntry>();
    }

    public void WriteEntry()
    {
        // Simplified prompt list for demonstration
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        Random random = new Random();
        string randomPrompt = prompts[random.Next(prompts.Count)];

        DailyPromptJournalEntry entry = new DailyPromptJournalEntry
        {
            Date = DateTime.Now,
            Prompt = randomPrompt
        };

        Console.WriteLine($"Prompt: {randomPrompt}");
        Console.Write("Response: ");
        entry.Response = Console.ReadLine();

        entries.Add(entry);
    }

    public void DisplayJournal()
    {
        foreach (var entry in entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                outputFile.WriteLine($"{entry.Date.ToShortDateString()},{entry.Prompt},{entry.Response}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        entries.Clear();

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);

            foreach (var line in lines)
            {
                string[] parts = line.Split(',');

                DailyPromptJournalEntry entry = new DailyPromptJournalEntry
                {
                    Date = DateTime.Parse(parts[0]),
                    Prompt = parts[1],
                    Response = parts[2]
                };

                entries.Add(entry);
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    journal.WriteEntry();
                    break;
                case 2:
                    journal.DisplayJournal();
                    break;
                case 3:
                    Console.Write("Enter the filename to save: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;
                case 4:
                    Console.Write("Enter the filename to load: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}