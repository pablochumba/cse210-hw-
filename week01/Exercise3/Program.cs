using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 100);
        
        Console.Write("What is your guess? ");
        string guess = Console.ReadLine();
        int numberGuess = int.Parse(guess);

        while (number != numberGuess)
        {

            if (number > numberGuess)
            {
                Console.WriteLine("Higher");
                Console.Write("What is your guess? ");
                guess = Console.ReadLine();
                numberGuess = int.Parse(guess);
            }

            else if (number < numberGuess)
            {
                Console.WriteLine("Lower");
                Console.Write("What is your guess? ");
                guess = Console.ReadLine();
                numberGuess = int.Parse(guess);
            }
        }
        
        Console.WriteLine("Congratulations! You guessed the magic number!");
    }
}