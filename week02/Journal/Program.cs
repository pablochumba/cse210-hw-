using System;

class Program
{
    static void ShowMenu()
    {
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal entries");
        Console.WriteLine("3. Save the journal to a file");
        Console.WriteLine("4. Load the journal from a file");
        Console.WriteLine("5. Exit");
    }

    static void Main(string[] args)
    {
        // To exceed requirements, each journal entry now tracks mood before and after writing.

        Console.WriteLine("Welcome to your personal journal! Let's reflect on your day together.");

        Journal journal = new Journal();
        string choice = "";

        while (choice != "5")
        {
            ShowMenu();
            Console.Write("Select an option: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                journal.AddEntry();
                Console.WriteLine("Your response has been recorded.");
            }
            else if (choice == "2")
            {
                journal.DisplayJournal();
            }
            else if (choice == "3")
            {
                Console.Write("Enter filename: ");
                string filename = Console.ReadLine();
                journal.SaveJournal(filename);
                Console.WriteLine("Your journal has been saved successfully.");
            }
            else if (choice == "4")
            {
                Console.Write("Enter filename: ");
                string filename = Console.ReadLine();
                journal.LoadJournal(filename);
                Console.WriteLine("Your journal has been loaded successfully.");
            }
            else if (choice != "5")
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }

        Console.WriteLine("Thank you for taking the time to reflect on your day.");
    }
}
