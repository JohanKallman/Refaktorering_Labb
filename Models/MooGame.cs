using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using refaktorering_labb.Interfaces;
using Refaktorering_Labb.Models;

namespace refaktorering_labb.Models
{
  public class MooGame : IGame
  {
    public string GameName { get; set; } = "MooGame";
    public string Rules { get; set; } = "Guess must contain 4 characters between 0-9!";
    public int TopOfGuessingNumberSpan { get; set; } = 10;
    //public bool GameIsRunning { get; set; } = false;
    public bool PlayerIsGuessing { get; set; } = false;

    public string CorrectAnswer { get; set; } = "";
    public int NumberOfGuesses { get; set; } = 0;
    public string PlayerGuess { get; set; }
    public string PlayerName { get; set; }





    //public bool GameIsRunning { get; set; }

    public MooGame()
    {
      // GameName = "TestGame";
      // Rules = "Guess must contain 4 characters between 0-9!";
      // TopOfGuessingNumberSpan = 10;
      // GameIsRunning = false;
      // PlayerGuessing = true;
      // CorrectAnswer = "";
      // NumberOfGuesses = 0;

    }


    public static string GenerateCorrectAnswer(int topOfGuessingNumberSpan)
    {
      // DO BETTER
      Random randomGenerator = new Random();
      string correctAnswer = "";
      for (int i = 0; i < 4; i++)
      {
        int random = randomGenerator.Next(topOfGuessingNumberSpan);
        string randomDigit = random.ToString();
        while (correctAnswer.Contains(randomDigit))
        {
          random = randomGenerator.Next(10);
          randomDigit = random.ToString();
        }
        correctAnswer = correctAnswer + randomDigit;
      }
      return correctAnswer;
    }

    public void StartNewInstanceOfGame()
    {
      CorrectAnswer = GenerateCorrectAnswer(TopOfGuessingNumberSpan);
      Console.WriteLine("For practice, number is: " + CorrectAnswer + "\n"); // Till UI
    }



    public bool CheckIfCorrectLengthFormat(string guess)
    {
      int numberOfAllowedCharachters = 4;
      if (guess.Length == numberOfAllowedCharachters)
      {
        return true;
      }

      return false;
    }

    public bool CheckIfCorrectCharFormat(string guess)
    {
      if (guess.All(char.IsDigit))
      {
        return true;
      }

      return false;
    }

    public string PrepareRoundResult(string guess)
    {
      PlayerGuess = guess;
      return ReturnOutputAfterGuess(guess);
    }
    public string ReturnOutputAfterGuess(string guess)
    {
      int numberExistsWrongPositionCounter = 0;
      int correctPositionCounter = 0;
      guess += "    ";     // if player entered less than 4 chars
      for (int i = 0; i < 4; i++)
      {
        for (int j = 0; j < 4; j++)
        {
          if (CorrectAnswer[i] == guess[j])
          {
            if (i == j)
            {
              correctPositionCounter++;
            }
            else
            {
              numberExistsWrongPositionCounter++;
            }
          }
        }
      }
      return "BBBB".Substring(0, correctPositionCounter) + "," + "CCCC".Substring(0, numberExistsWrongPositionCounter);
    }

    public bool CheckGameWinningCondition(string resultAfterGuess)
    {
      if (resultAfterGuess == "BBBB,")
      {
        return false;
      }
      return true;
    }

    public bool CheckIfPlayAgain(string answer)
    {
      if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
      {
        return false;
      }

      return true;
    }

    public string PlayerGuesses()
    {
      NumberOfGuesses++;

      return Console.ReadLine().Trim();
    }
  }
}