using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool running = true;

        while (running)
        {
            SafeClearScreen();
            DisplayPlayerInfo();
            DisplayLevel();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine() ?? string.Empty;
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            if (running)
            {
                Pause();
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string goalType = Console.ReadLine() ?? string.Empty;

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine() ?? string.Empty;

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine() ?? string.Empty;

        int points = ReadInt("How many points is it worth? ");

        Goal goal;

        switch (goalType)
        {
            case "1":
                goal = new SimpleGoal(name, description, points);
                break;
            case "2":
                goal = new EternalGoal(name, description, points);
                break;
            case "3":
                int target = ReadInt("How many times does this goal need to be accomplished for a bonus? ");
                int bonus = ReadInt("What is the bonus for accomplishing it that many times? ");
                goal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        _goals.Add(goal);
        Console.WriteLine("Goal created successfully.");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals are available to record.");
            return;
        }

        Console.WriteLine("The goals are:");
        ListGoalNames();
        int goalNumber = ReadInt("Which goal did you accomplish? ");

        if (goalNumber < 1 || goalNumber > _goals.Count)
        {
            Console.WriteLine("Invalid goal selection.");
            return;
        }

        Goal selectedGoal = _goals[goalNumber - 1];
        int earnedPoints = selectedGoal.RecordEvent();
        _score += earnedPoints;

        if (earnedPoints > 0)
        {
            Console.WriteLine($"Congratulations! You have earned {earnedPoints} points!");
            Console.WriteLine($"You now have {_score} points.");
        }
        else
        {
            Console.WriteLine("That goal is already complete, so no additional points were awarded.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine() ?? string.Empty;

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine() ?? string.Empty;

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        _goals.Clear();

        if (lines.Length == 0)
        {
            _score = 0;
            Console.WriteLine("File loaded, but it did not contain any goals.");
            return;
        }

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            Goal goal = CreateGoalFromString(lines[i]);
            if (goal != null)
            {
                _goals.Add(goal);
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }

    private Goal CreateGoalFromString(string data)
    {
        string[] parts = Goal.SplitEscapedParts(data);

        if (parts.Length < 4)
        {
            return null;
        }

        string goalType = parts[0];

        switch (goalType)
        {
            case "SimpleGoal":
                return new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]));
            case "EternalGoal":
                return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
            case "ChecklistGoal":
                return new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[5]), int.Parse(parts[4]), int.Parse(parts[6]));
            default:
                return null;
        }
    }

    private int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? string.Empty;

            if (int.TryParse(input, out int value))
            {
                return value;
            }

            Console.WriteLine("Please enter a valid whole number.");
        }
    }

    private void DisplayLevel()
    {
        Console.WriteLine($"Current rank: {GetRankTitle()}");
    }

    private string GetRankTitle()
    {
        if (_score >= 5000)
        {
            return "Master Disciple";
        }

        if (_score >= 2500)
        {
            return "Faithful Finisher";
        }

        if (_score >= 1000)
        {
            return "Steady Seeker";
        }

        if (_score >= 250)
        {
            return "Rising Pilgrim";
        }

        return "New Adventurer";
    }

    private void Pause()
    {
        Console.WriteLine();
        Console.Write("Press Enter to continue... ");
        Console.ReadLine();
    }

    private void SafeClearScreen()
    {
        try
        {
            if (!Console.IsOutputRedirected)
            {
                Console.Clear();
            }
        }
        catch (IOException)
        {
        }
    }
}
