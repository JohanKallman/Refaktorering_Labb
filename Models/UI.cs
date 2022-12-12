using System;

namespace Refactoring_Lab.Models
{
    public class UI
    {


        public UI()
        {

        }

        public void PrintEnterNameMessage()
        {
            Console.Write("Enter name: ");

        }


        public void PrintWelcomeMessage(string gameName)
        {
            Console.WriteLine($"\nWelcome to {gameName}!\n");
        }

        public void PrintGameMenuOptions()
        {
            Console.Write("Please choose game. \n" +
                              "[1] Moo Game \n" +
                              "[2] Mastermind \n\n" +
                              "[Q] Turn off game  \n\n" +
                              "[: ");
        }

        public void PrintRulesMessage(string rules)
        {
            Console.WriteLine(rules + "\n");
        }

        //=============================================
        // The +1 is needed because the guessing counter
        // increments after this message.  
        //-----------------------------------------
        public void PrintRoundStartMessage(int round)
        {
            Console.WriteLine($"Round {round + 1}!");

        }


        public void PrintResultOfGameSession(int numberOfGuesses)
        {
            Console.WriteLine("Correct, it took " + numberOfGuesses + " guesses!\n");
        }

        public void PrintResultOfPlayerGuess(string inputGuess, string outputResult)
        {
            Console.WriteLine($"\nYou guessed: {inputGuess}");
            Console.WriteLine($"Result: {outputResult} \n");
        }

        public void PrintAskToPlayAgainMessage()
        {
            Console.WriteLine("To play again press any key.\n" +
                              "To quit press 'Q'");
        }

        public void PrintTopListListMessage()
        {
            Console.WriteLine("<([ TOP LIST ])>");
        }

        public void PrintInputErrorMessage()
        {
            Console.WriteLine("\nWrong input format!");
        }

        public void PrintGuessHereMessage()
        {
            Console.Write("Your guess: ");
        }

        public void PrintGoodByeMessage()
        {
            Console.WriteLine("Thank you for playing!");
        }

        public void PrintTopList(string topList)
        {
            Console.WriteLine(topList);
        }







    }
}