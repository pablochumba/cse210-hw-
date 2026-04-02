using System;

class Program
{
    static void Main(string[] args)
    {
        // It exceeds requirements by tracking completed activities for the current session
        // and by cycling through prompts/questions before repeating them.
        BreathingActivity breathingActivity = new BreathingActivity();
        ReflectionActivity reflectionActivity = new ReflectionActivity();
        ListingActivity listingActivity = new ListingActivity();

        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflection activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.WriteLine();
            Console.WriteLine($"Completed this session: Breathing {breathingActivity.GetCompletedCount()}, Reflection {reflectionActivity.GetCompletedCount()}, Listing {listingActivity.GetCompletedCount()}");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Clear();
                breathingActivity.Run();
            }
            else if (choice == "2")
            {
                Console.Clear();
                reflectionActivity.Run();
            }
            else if (choice == "3")
            {
                Console.Clear();
                listingActivity.Run();
            }
            else if (choice == "4")
            {
                isRunning = false;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Invalid choice. Please try again.");
                Thread.Sleep(1500);
            }
        }
    }
}
