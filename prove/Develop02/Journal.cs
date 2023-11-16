using System;
using System.IO;
using System.Collections.Generic;



public class Journal
{
    public string _filename;
    public string _deletingNumber;

    public List<Entry> Entries = new List<Entry>(); //Now we use a "list" of the entry class

    public void addingEntries(Entry entry)
    {
        Entries.Add(entry);
    }

    public void displayingJournal()
    {
        for (int numbersToDisplay = 0; numbersToDisplay < Entries.Count; numbersToDisplay++)
        {
            Console.WriteLine($"Entry #{numbersToDisplay + 1}.\nDate: {Entries[numbersToDisplay]._todayDate} - Prompt: {Entries[numbersToDisplay]._prompt}\n{Entries[numbersToDisplay]._answer}\n");

        }
    }

    public void saving()
    {

        using (StreamWriter outputFile = new StreamWriter(_filename, true))
        {
            foreach (Entry entry in Entries)
            {
                outputFile.WriteLine($"{entry._todayDate}|{entry._prompt}|{entry._answer}");
            }
        }
    }
    public void loading()
    {
        Entries.Clear();
        string[] lines = System.IO.File.ReadAllLines(_filename);



        foreach (string line in lines)
        {
            string[] fields = line.Split("|");
            Entry entry = new Entry();
            {
                entry._todayDate = fields[0].Trim();
                entry._prompt = fields[1].Trim();
                entry._answer = fields[2].Trim();
            }
            Entries.Add(entry);
        }

    }

    public void deleting()
    {
        int ripEntry = int.Parse(_deletingNumber);

        if (ripEntry >= 1 && ripEntry <= Entries.Count)
        {
            Entries.RemoveAt(ripEntry - 1);
            Console.WriteLine($"\nDELETING entry #{ripEntry}.... 50%\nDELETING entry #{ripEntry}.... 99%\nEntry #{ripEntry} deleted successfully!");

        }
        else
        {
            Console.WriteLine("\nWow! It looks like this number does not exist yet! No memories were deleted!");
        }

    }
}