namespace NumbersGame;

class Program
{
    static void Main(string[] args)
    {
        GuessNumbersGame();
    }

    /// <summary>
    /// A method that run the GuessNumbersGame
    /// </summary>
    public static void GuessNumbersGame()
    {
        //create a new instance och the class Random
        Random random = new Random();

        //use the random-method Next() to generate random number between 1 and 20. 
        int theNumber = random.Next(1, 21);

        Console.WriteLine("Välkommen! Jag tänker på ett nummer mellan 1 och 20. Kan du " +
                          "gissa vilket? Du får fem försök");
        
        int numberTried = 0;
        bool wonGame = false;

        while (numberTried <= 5 && !wonGame)
        {
            bool testAnswer = Int32.TryParse(Console.ReadLine(), out int guessedNum);

            while (!testAnswer || guessedNum < 1 || guessedNum > 20)
            {
                Console.WriteLine("Felaktig input! Du ska gissa på ett tal mellan 1 och 20");
            }
            
            numberTried++;
            
            if (guessedNum == theNumber)
            {
                Console.WriteLine($"Wohoo! Du gjorde det! Du gissade rätt på försök nr {numberTried}! Grattis! :)");
                wonGame = true;
            }
            else if (guessedNum < theNumber)
            {
                Console.WriteLine("Tyvärr du gissade för lågt! Försök igen!");
            }
            else if (guessedNum > theNumber)
            {
                Console.WriteLine("Tyvärr du gissade för högt! Försök igen!");
            }
            
        }
    }
}