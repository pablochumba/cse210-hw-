public class Entry
{
    public string _moodBefore = "";
    public string _moodAfter = "";
    public string _date = "";
    public string _prompt = "";
    public string _entry = "";

    public void DisplayEntry()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Mood Before: {_moodBefore}");
        Console.WriteLine($"Entry: {_entry}");
        Console.WriteLine($"Mood After: {_moodAfter}");
    }
}
