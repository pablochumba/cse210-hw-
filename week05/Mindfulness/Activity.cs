using System;

public abstract class Activity
{
    private string _name;
    private string _description;
    private int _duration;
    private int _completedCount;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
        _completedCount = 0;
    }

    public void Run()
    {
        DisplayStartingMessage();
        PerformActivity();
        _completedCount++;
        DisplayEndingMessage();
    }

    public int GetCompletedCount()
    {
        return _completedCount;
    }

    protected int GetDuration()
    {
        return _duration;
    }

    protected string GetName()
    {
        return _name;
    }

    protected abstract void PerformActivity();

    private void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.\n");
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");

        string response = Console.ReadLine();
        while (!int.TryParse(response, out _duration) || _duration <= 0)
        {
            Console.Write("Please enter a positive number of seconds: ");
            response = Console.ReadLine();
        }

        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(4);
        Console.WriteLine();
    }

    private void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(4);
        Console.WriteLine();
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int index = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[index]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            index = (index + 1) % spinner.Length;
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}
