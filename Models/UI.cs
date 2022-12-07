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

    public void PrintChooseGameMessage()
    {
      Console.Write("Please choose game. \n" +
                        "[1] Moo Game \n" +
                        "[2] Mastermind\n\n" +
                        //"[Q] Quit"+
                        "[: ");
    }

    public void PrintRulesMessage(string rules)
    {
      Console.WriteLine(rules + "\n");
    }

    public void PrintRoundStartMessage(int round)
    {
      Console.WriteLine($"Round {round + 1}!");

    }

    public void PrintResultOfInstanceMessage(int numberOfGuesses)
    {
      Console.WriteLine("Correct, it took " + numberOfGuesses + " guesses!\n");
    }

    public void PrintResultOfPlayerGuessMessage(string inputGuess, string outputResult)
    {
      Console.WriteLine($"\nYou guessed: {inputGuess}");
      Console.WriteLine($"Result: {outputResult} \n");
    }

    public void PrintAskToPlayAgainMessage()
    {
      Console.WriteLine("Would you like to play again? y/n?\n");
    }

    public void PrintHighScoreListMessage()
    {
      Console.WriteLine("<([ HIGH SCORE ])>");
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







  }
}