using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void PerformActivity()
    {
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            int inhaleSeconds = Math.Min(4, Math.Max(1, (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds)));
            Console.Write("Breathe in... ");
            ShowCountdown(inhaleSeconds);
            Console.WriteLine();

            if (DateTime.Now >= endTime)
            {
                break;
            }

            int exhaleSeconds = Math.Min(4, Math.Max(1, (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds)));
            Console.Write("Breathe out... ");
            ShowCountdown(exhaleSeconds);
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
