using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _remainingPrompts;
    private Random _random;

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        _remainingPrompts = new List<string>();
        _random = new Random();
    }

    protected override void PerformActivity()
    {
        List<string> items = new List<string>();

        Console.WriteLine("List as many responses as you can to the following prompt:\n");
        Console.WriteLine($"--- {GetNextPrompt()} ---");
        Console.WriteLine();
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();
        Console.WriteLine("Start listing items:");

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string entry = ReadLineWithDeadline(endTime);

            if (entry == null)
            {
                break;
            }

            if (!string.IsNullOrWhiteSpace(entry))
            {
                items.Add(entry);
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {items.Count} items!");
    }

    private string GetNextPrompt()
    {
        if (_remainingPrompts.Count == 0)
        {
            _remainingPrompts = new List<string>(_prompts);
        }

        int index = _random.Next(_remainingPrompts.Count);
        string prompt = _remainingPrompts[index];
        _remainingPrompts.RemoveAt(index);
        return prompt;
    }

    private string ReadLineWithDeadline(DateTime deadline)
    {
        StringBuilder builder = new StringBuilder();

        while (DateTime.Now < deadline)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    return builder.ToString();
                }

                if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (builder.Length > 0)
                    {
                        builder.Length--;
                        Console.Write("\b \b");
                    }
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    builder.Append(keyInfo.KeyChar);
                    Console.Write(keyInfo.KeyChar);
                }
            }
            else
            {
                Thread.Sleep(50);
            }
        }

        Console.WriteLine();
        return null;
    }
}
