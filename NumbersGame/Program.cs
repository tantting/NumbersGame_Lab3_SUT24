//SUT24, Jenny-Ann Hayward
namespace NumbersGame;

class Program
{
    static void Main(string[] args)
    {
        //Initiate a bool to "control" the loop
        bool playOn = true;

        while (playOn)
        {
            Console.Clear();
            Console.WriteLine("Välkommen till Gissa Numret!\n\nVill på att spela? (ja/nej)");

            switch (Console.ReadLine().ToLower())
            {
                case "ja":
                    //calls the method GuessNumbersGame to run the game (se methods after main)
                    GuessNumbersGame();
                    break;
                case "nej":
                    Console.WriteLine("En annan gång kanske! :) Adjö!");
                    //when playOn turns false, the while loop stops
                    playOn = false;
                    break;
                default:
                    Console.WriteLine("Jag förtod inte riktigt! Försök igen genom att " +
                                      "trycka valfri tangent!");
                    Console.ReadKey();
                    break;
            }
        }
    }

    /// <summary>
    /// A method that run the GuessNumbersGame
    /// </summary>
    public static void GuessNumbersGame()
    {
        Console.Clear();
        //create a new instance och the class Random
        Random random = new Random();

        //use the random-method Next() to generate random number between 1 and 20. 
        int theNumber = random.Next(1, 21);

        Console.WriteLine("Jag tänker på ett nummer mellan 1 och 20. Kan du " +
                          "gissa vilket? Du får fem försök!");
        
        int numberTried = 0;
        bool endGame = false; 
        
        //As long as endGame is set to false, the loop will continue. 
        while (!endGame)
        {
            //initiate a bool with the value of a TryParse to ensure correct input.
            bool testAnswer = Int32.TryParse(Console.ReadLine(), out int guessedNum);

            while (!testAnswer || guessedNum < 1 || guessedNum > 20)
            {
                Console.WriteLine("Felaktig input! Du ska gissa på ett tal mellan 1 och 20");
            }
            //the method CheckGuess writes out wether the guess is correct or not and returns a bool
            //that is true if the winner has guessed correct, otherwise false. 
            endGame = CheckGuess(guessedNum, theNumber);
            
            //increases the number tried by one
            numberTried++;
            
            //when the user has guessed a number 5 times (and failed all of them) it will be notified and
            //endGame is set to true to break the loop. 
            if (numberTried == 5 && !endGame)
            {
                Console.WriteLine($"\nDet var ditt sista försök dessvärre! Numret jag tänkte på " +
                                  $"var {theNumber}. Bättre lycka nästa gång!\n\nTryck valfri tangent " +
                                  $"för att fortsätta ");
                Console.ReadKey();
                endGame = true;
            }
        }
    }
    
    /// <summary>
    /// A mehod for checking if the guessed number i correct, low or high.
    /// </summary>
    /// <param name="guessedNum"></param>
    /// <param name="theNumber"></param>
    /// <param name="wonGame"></param>
    /// <returns></returns>
    public static bool CheckGuess(int guessedNum, int theNumber)
    {
        //a bool that is false until the player potentially guess the right number
        bool wonGame = false;
        
        if (guessedNum == theNumber)
        {
            Console.WriteLine($"Wohoo! Du gjorde det! Du gissade rätt! Grattis!\n\nTryck valfri tangent" +
                              $"för att fortsätta :)");
            Console.ReadKey();
            wonGame = true;
        }
        else if (guessedNum < theNumber)
        {
            Console.WriteLine("Tyvärr du gissade för lågt!");
            //calls a method that check wether the guess is close. If so an additional message will be printed.
            ItIsClose(guessedNum, theNumber);
        }
        else if (guessedNum > theNumber)
        {
            Console.WriteLine("Tyvärr du gissade för högt!");
            ItIsClose(guessedNum, theNumber);
        }

        return wonGame;
    }
    
    /// <summary>
    /// A method that checks if the absolute number is less than 1 or 2. If so it writes a message to
    /// the console. 
    /// </summary>
    /// <param name="guessedNum"></param>
    /// <param name="theNumber"></param>
    public static void ItIsClose(int guessedNum, int theNumber)
    {
        int diff = guessedNum - theNumber;
        
        //Use Math.Abs to retrieve the absolute value of the difference between number gussed and the 
        //"correct" number.
        if (Math.Abs(diff) == 2)
        {
            Console.WriteLine("Meeen...det bränns!");
        }
        else if (Math.Abs(diff) == 1)
        {
            Console.WriteLine("Ojojoj...det är supervarmt ju!");
        }
    }
}