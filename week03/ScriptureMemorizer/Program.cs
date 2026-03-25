using System;

class Program
{
    static void Main(string[] args)
    {
        // I added a scripture library and use Random to pick one scripture from it each time the program starts.
        List<Scripture> library = new List<Scripture>
        {
            new Scripture(new Reference("2 Nephi", 2, 25), "Adam fell that men might be and men are that they might have joy"),
            new Scripture(new Reference("2 Nephi", 31, 20), "Wherefore ye must press forward with a steadfastness in Christ having a perfect brightness of hope"),
            new Scripture(new Reference("Moroni", 10, 4), "And when ye shall receive these things I would exhort you that ye would ask God the Eternal Father in the name of Christ if these things are not true"),
            new Scripture(new Reference("Alma", 37, 6), "Now ye may suppose that this is foolishness in me but behold I say unto you that by small and simple things are great things brought to pass"),
            new Scripture(new Reference("Mosiah", 2, 17), "And behold I tell you these things that ye may learn wisdom that ye may learn that when ye are in the service of your fellow beings ye are only in the service of your God"),
            new Scripture(new Reference("Ether", 12, 27), "And if men come unto me I will show unto them their weakness I give unto men weakness that they may be humble"),
            new Scripture(new Reference("3 Nephi", 13, 33), "But seek ye first the kingdom of God and his righteousness and all these things shall be added unto you")
        };

        Random random = new Random();
        Scripture scripture = library[random.Next(library.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nAll words hidden. Well done!");
                break;
            }

            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit:");
            string input = Console.ReadLine() ?? string.Empty;

            if (input.ToLower() == "quit")
            {
                break;
            }

            if (input == string.Empty)
            {
                scripture.HideRandomWords(3);
            }
        }
    }
}
