using System;
using System.Linq;

namespace Refactoring_Lab.Models
{
  public abstract class Game
  {
    public string GameName { get; set; }
    public string Rules { get; set; }
    public int TopOfGuessingNumberSpan { get; set; }
    public bool GameIsRunning { get; set; }
    public bool ActiveGame { get; set; }
    public static bool PlayerGuessing { get; set; }
    public string PlayerName { get; set; }
    public string PlayerGuess { get; set; }
    public static string CorrectAnswer { get; set; }
    public int NumberOfGuesses { get; set; }

    public int HighestRandomNumber { get; set; }
    public int LowestRandomNumber { get; set; }
    public int AmountOfIntegersInAnswer { get; set; }
    public string OutPutResult { get; set; }
    public bool ValidGuess { get; set; }

    public void SetPlayerName()
    {
      PlayerName = Console.ReadLine();

    }

    public void StartNewInstanceOfGame()
    {
      CorrectAnswer = GenerateCorrectAnswer();

      Console.WriteLine("For practice, number is: " + CorrectAnswer + "\n"); // Till UI
    }

        //public abstract void PrepareRoundResult();
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
      IncrementGuessingCounterByOne();

      PlayerGuess = Console.ReadLine().Trim();
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

    // public bool CheckGameWinningCondition()
    // {
    //   if (OutPutResult == "BBBB,")
    //   {
    //     return false;
    //   }
    //   return true;
    // }

    public void CheckIfGameIsOver()
    {
      if (OutPutResult == "BBBB,")
      {
        ActiveGame = false;
      }


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
