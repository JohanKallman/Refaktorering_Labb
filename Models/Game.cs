﻿using System;
using System.Linq;

namespace Refactoring_Lab.Models
{
  public abstract class Game
  {
    //TODO: ändra bool-namngivning till IsActive, IsPlayerGuessing etc..
    public string GameName { get; set; }
    public string Rules { get; set; }
    public bool GameIsRunning { get; set; }
    public string CorrectAnswer { get; set; }
    public int HighestRandomNumber { get; set; }
    public int LowestRandomNumber { get; set; }
    public int AmountOfIntegersInAnswer { get; set; }
    public string OutPutResult { get; set; }
    public bool PlayerIsGuessing { get; set; }
    public string PlayerGuess { get; set; }



    public int NumberOfGuesses { get; set; }
    public bool ValidGuess { get; set; }



    public void StartNewInstanceOfGame()
    {
      ResetGuessingCounter();
      CorrectAnswer = GenerateCorrectAnswer();

      Console.WriteLine("For practice, number is: " + CorrectAnswer + "\n"); // Till UI
    }


    public virtual void PrepareRoundResult()
    {
      OutPutResult = ReturnOutputAfterGuess();
    }

    public string GenerateCorrectAnswer()
    {
      Random numberGenerator = new Random();
      string uniqueNumberToReturn = "";
      while (uniqueNumberToReturn.Length < AmountOfIntegersInAnswer)
      {
        int newNumber = numberGenerator.Next(LowestRandomNumber, HighestRandomNumber);
        if (!uniqueNumberToReturn.Contains(newNumber.ToString()))
        {
          uniqueNumberToReturn += newNumber.ToString();
        }
      }
      return uniqueNumberToReturn;
    }

    public void ResetGuessingCounter()
    {
      NumberOfGuesses = 0;
    }

    public void PlayerGuesses()
    {
      PlayerGuess = Console.ReadLine().Trim();
      IncrementGuessingCounterByOne();
    }

    public void IncrementGuessingCounterByOne()
    {
      NumberOfGuesses++;

    }



    public void ValidateInputGuess()
    {
      ValidGuess = CheckIfAcceptedFormat();

      // bool guessHasCorrectFormat = CheckIfCorrectLengthFormat();

      // if (guessHasCorrectFormat == false)
      // {
      //   return false;
      // }

      // return guessHasCorrectFormat = CheckIfCorrectCharFormat();

    }

    public bool CheckIfAcceptedFormat()
    {
      bool guessHasCorrectFormat = CheckIfCorrectLengthFormat();

      if (guessHasCorrectFormat == false)
      {
        return false;
      }

      return guessHasCorrectFormat = CheckIfCorrectCharFormat();
    }

    public bool CheckIfCorrectLengthFormat()
    {

      if (PlayerGuess.Length == AmountOfIntegersInAnswer)
      {
        return true;
      }

      return false;
    }

    // public bool CheckIfCorrectLengthFormat()
    // {
    //   int numberOfAllowedCharachters = 4;
    //   if (PlayerGuess.Length == numberOfAllowedCharachters)
    //   {
    //     return true;
    //   }

    //   return false;
    // }

    public bool CheckIfCorrectCharFormat()
    {
      if (PlayerGuess.All(char.IsDigit))
      {
        return true;
      }

      return false;
    }

    // public string PrepareRoundResult()
    // {

    //   return ReturnOutputAfterGuess();
    // }

    public string ReturnOutputAfterGuess()
    {
      int numberExistsWrongPositionCounter = 0;
      int correctPositionCounter = 0;

      for (int i = 0; i < 4; i++)
      {
        for (int j = 0; j < 4; j++)
        {
          if (CorrectAnswer[i] == PlayerGuess[j])
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

    public void CheckIfGameIsOver()
    {
      if (OutPutResult == "BBBB,")
      {
        PlayerIsGuessing = false;
      }


    }
    public bool CheckIfPlayAgain()
    {
      if (Console.ReadLine().ToUpper() == "Q")
      {
        return false;
      }
      return true;
    }

  }


}
