using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string grade = Console.ReadLine();
        int number = int.Parse(grade);

        string letter = "A"; 

        if (number >= 90)
        {
            Console.WriteLine($"You got an {letter}");
        }        

        else if (number >= 80)
        {
            letter = "B";
            Console.WriteLine($"You got a {letter}");
        }        

        else if (number >= 70)
        {
            letter = "C";
            Console.WriteLine($"You got a {letter}");
        }        

        else if (number >= 60)
        {
            letter = "D";
            Console.WriteLine($"You got a {letter}");
        }        

        else if (number < 60)
        {
            letter = "F";
            Console.WriteLine($"You got a {letter}");
        }        

        if (number >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course!");
        }

        else
        {
            Console.WriteLine("Better luck next time!");
        }
    }
}