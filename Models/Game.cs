using System;
using System.Linq;

namespace Refactoring_Lab.Models
{
  public abstract class Game
  {
    public string GameName { get; set; }
    public string Rules { get; set; }
    public bool GameIsRunning { get; set; }

    // Ny klass Answer?
    public string CorrectAnswer { get; set; }
    public int HighestRandomNumber { get; set; }
    public int LowestRandomNumber { get; set; }
    public int AmountOfIntegersInAnswer { get; set; }

    // Ny klass PlayerGuess?
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
      string correctAnswer = "";
      while (correctAnswer.Length < AmountOfIntegersInAnswer)
      {
        int newNumber = numberGenerator.Next(LowestRandomNumber, HighestRandomNumber);
        correctAnswer = CheckIfUniqueNumberIsRequired(correctAnswer, newNumber);
      }
      return "4423";
      //return correctAnswer;
    }

    public virtual string CheckIfUniqueNumberIsRequired(string correctAnswer, int newNumber)
    {
      if (!correctAnswer.Contains(newNumber.ToString()))
      {
        correctAnswer += newNumber.ToString();
      }

      return correctAnswer;
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

    // public string ReturnOutputAfterGuess()
    // {
    //   int numberExistsWrongPositionCounter = 0;
    //   int correctPositionCounter = 0;

    //   for (int i = 0; i < 4; i++)
    //   {
    //     for (int j = 0; j < 4; j++)
    //     {
    //       if (CorrectAnswer[i] == PlayerGuess[j])
    //       {
    //         if (i == j)
    //         {
    //           correctPositionCounter++;
    //         }
    //         else
    //         {
    //           numberExistsWrongPositionCounter++;
    //         }
    //       }
    //     }
    //   }
    //   return "BBBB".Substring(0, correctPositionCounter) + "," + "CCCC".Substring(0, numberExistsWrongPositionCounter);
    // }

    public string ReturnOutputAfterGuess()
    {
      int numberExistsWrongPositionCounter = 0;
      int correctPositionCounter = 0;
      string[] correctAnswerCheck = { "", "", "", "" };
      string[] correctGuessCheck = { "", "", "", "" };
      for (int i = 0; i < 4; i++)
      {
        for (int j = 0; j < 4; j++)
        {
          if (CorrectAnswer[i] == PlayerGuess[j] && correctAnswerCheck[i] != "X" && correctGuessCheck[j] != "X")
          {
            correctAnswerCheck[i] = "X";
            correctGuessCheck[j] = "X";

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
