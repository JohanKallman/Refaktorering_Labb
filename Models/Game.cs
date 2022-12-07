﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using refaktorering_labb.Interfaces;
using refaktorering_labb.Models;

namespace Refaktorering_Labb.Models
{
  public abstract class Game
  {
    // public UI _uI;
    // public Statistics _statistics;
    // public GameMechanics _gameMechanics;

    public string GameName { get; set; }
    public string Rules { get; set; }
    public int TopOfGuessingNumberSpan { get; set; }
    public bool GameIsRunning { get; set; }
    public bool PlayerIsGuessing { get; set; }
    public static bool PlayerGuessing { get; set; }
    public string PlayerName { get; set; }
    public string PlayerGuess { get; set; }
    public static string CorrectAnswer { get; set; }
    public int NumberOfGuesses { get; set; }

    public int HighestRandomNumber { get; set; }
    public int LowestRandomNumber { get; set; }
    public int AmountOfIntegersInAnswer { get; set; }
    public string OutPutResult { get; set; }

    public void StartNewInstanceOfGame()
    {
      CorrectAnswer = GenerateCorrectAnswer();
      Console.WriteLine("For practice, number is: " + CorrectAnswer + "\n"); // Till UI
    }

    public abstract void PrepareRoundResult();

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

    public string PlayerGuesses()
    {
      IncrementGuessingCounterByOne();

      return Console.ReadLine().Trim();
    }

    public void IncrementGuessingCounterByOne()
    {
      NumberOfGuesses++;

    }

    public bool CheckIfCorrectLengthFormat()
    {
      int numberOfAllowedCharachters = 4;
      if (PlayerGuess.Length == numberOfAllowedCharachters)
      {
        return true;
      }

      return false;
    }

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

    public bool CheckGameWinningCondition()
    {
      if (OutPutResult == "BBBB,")
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

  }


}
