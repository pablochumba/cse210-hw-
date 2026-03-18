using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    public List<string> _prompts = new List<string>()
    {
        "What is one thing that drained your energy today, and one thing that restored it?",
        "Did you do something today that your future self will thank you for?",
        "What is one small win you had today, even if nobody noticed?",
        "If you could redo one moment from today, what would it be and why?",
        "Who made your day a little better today, even in a small way?",
        "What emotion showed up the most today, and where did you feel it in your body?",
        "What is something you are carrying right now that you need to let go of?",
        "What made you smile today, even for just a second?"
    };

    public void AddEntry()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        string prompt = _prompts[index];

        Console.WriteLine(prompt);
        Console.Write("How are you feeling before writing? (1-10): ");
        string moodBefore = Console.ReadLine();
        Console.Write("> ");
        string response = Console.ReadLine();
        Console.Write("How are you feeling after writing? (1-10): ");
        string moodAfter = Console.ReadLine();

        Entry newEntry = new Entry();
        newEntry._date = DateTime.Now.ToShortDateString();
        newEntry._prompt = prompt;
        newEntry._entry = response;
        newEntry._moodBefore = moodBefore;
        newEntry._moodAfter = moodAfter;

        _entries.Add(newEntry);
    }

    public void DisplayJournal()
    {
        foreach (Entry entry in _entries)
        {
            entry.DisplayEntry();
            Console.WriteLine();
        }
    }

    public void SaveJournal(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry._date}|{entry._prompt}|{entry._entry}|{entry._moodBefore}|{entry._moodAfter}");
            }
        }
    }

    public void LoadJournal(string filename)
    {
        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");
            Entry entry = new Entry();
            entry._date = parts[0];
            entry._prompt = parts[1];
            entry._entry = parts[2];
            if (parts.Length > 3)
            {
                entry._moodBefore = parts[3];
            }

            if (parts.Length > 4)
            {
                entry._moodAfter = parts[4];
            }

            _entries.Add(entry);
        }
    }
}
