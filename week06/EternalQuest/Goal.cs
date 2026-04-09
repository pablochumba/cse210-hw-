using System.Collections.Generic;
using System.Text;

public abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;

    protected Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public string GetShortName()
    {
        return _shortName;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points;
    }

    public abstract int RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {_shortName} ({_description})";
    }

    public abstract string GetStringRepresentation();

    protected string EscapeValue(string value)
    {
        return value.Replace("\\", "\\\\").Replace("|", "\\|");
    }

    public static string[] SplitEscapedParts(string data)
    {
        List<string> parts = new List<string>();
        StringBuilder currentPart = new StringBuilder();
        bool isEscaping = false;

        foreach (char character in data)
        {
            if (isEscaping)
            {
                currentPart.Append(character);
                isEscaping = false;
            }
            else if (character == '\\')
            {
                isEscaping = true;
            }
            else if (character == '|')
            {
                parts.Add(currentPart.ToString());
                currentPart.Clear();
            }
            else
            {
                currentPart.Append(character);
            }
        }

        if (isEscaping)
        {
            currentPart.Append('\\');
        }

        parts.Add(currentPart.ToString());
        return parts.ToArray();
    }
}
