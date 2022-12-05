using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace refaktorering_labb.Models
{
  public class UI
  {

    public void PrintEnterNameMessage()
    {
      Console.Write("Enter name: ");

    }

    public UI()
    {

    }



    public void PrintWelcome(string gameName)
    {
      Console.WriteLine($"Welcome to {gameName}!");
    }

    public void PrintChooseGameMessage()
    {
      Console.WriteLine("Please choose game. \n" +
                        "[1] Moo Game \n" +
                        "[2] Mastermind");
    }

    public void PrintRules(string rules)
    {
      Console.WriteLine(rules);
    }

    public void RoundStartMessage(int round)
    {
      Console.WriteLine($"Round {round + 1}!");

    }

    public void PrintResultOfInstance(int numberOfGuesses)
    {
      Console.WriteLine("Correct, it took " + numberOfGuesses + " guesses");
    }

    public void PrintResultOfPlayerGuess(string inputGuess, string outputResult)
    {
      Console.WriteLine($"\nYou guessed: {inputGuess}");
      Console.WriteLine($"Result: {outputResult} \n");
    }

    public void PrintPlayAgainQuestion()
    {
      Console.WriteLine("Would you like to play again? y/n?");
    }

    public void PrintHighScoreListMessage()
    {
      Console.WriteLine("<([ HIGH SCORE ])>");
    }

    public void PrintInputErrorMessage()
    {
      Console.WriteLine("Fel format!");
    }

    public void PrintGuessHere()
    {
      Console.Write("Your guess: ");
    }

    public void PrintGoodByeMessage()
    {
      Console.WriteLine("Thank you for playing!");
    }







  }
}