using System;
using System.Linq;

namespace Refactoring_Lab.Models
{
  public abstract class Game
  {
    public string GameName { get; set; }
    public string Rules { get; set; }
    public bool GameIsRunning { get; set; } = false;
    public GameAnswer GameAnswer { get; set; } = new GameAnswer();
    public PlayerGuess PlayerGuess { get; set; } = new PlayerGuess();


    public void StartNewInstanceOfGame()
    {
      ResetGuessingCounter();
      GameAnswer.CorrectAnswer = GenerateCorrectAnswer();
      Console.WriteLine("For practice, number is: " + GameAnswer.CorrectAnswer + "\n");
    }


    public virtual void PrepareRoundResult()
    {
      PlayerGuess.OutPutResult = ReturnOutputAfterGuess();
    }

    public string GenerateCorrectAnswer()
    {
      Random numberGenerator = new Random();
      string correctAnswer = "";
      while (correctAnswer.Length < GameAnswer.AmountOfIntegersInAnswer)
      {
        int newNumber = numberGenerator.Next(GameAnswer.LowestRandomNumber, GameAnswer.HighestRandomNumber);
        correctAnswer = CheckIfUniqueNumberIsRequired(correctAnswer, newNumber);
      }
      return "3423";
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
      PlayerGuess.NumberOfGuesses = 0;
    }


    public void PlayerGuesses()
    {
      PlayerGuess.Guess = Console.ReadLine().Trim();
      IncrementGuessingCounterByOne();
    }




    public void IncrementGuessingCounterByOne()
    {
      PlayerGuess.NumberOfGuesses++;
    }


    public void ValidateInputGuess()
    {
      PlayerGuess.IsValidGuess = CheckIfAcceptedFormat();
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
      if (PlayerGuess.Guess.Length == GameAnswer.AmountOfIntegersInAnswer)
      {
        return true;
      }
      return false;
    }

    public bool CheckIfCorrectCharFormat()
    {
      if (PlayerGuess.Guess.All(char.IsDigit))
      {
        return true;
      }

      return false;
    }

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

          if (GameAnswer.CorrectAnswer[i] == PlayerGuess.Guess[j])
          {

            if (i == j)
            {
              if (correctAnswerCheck[i] == "C" || correctGuessCheck[i] == "C")
              {
                numberExistsWrongPositionCounter--;
              }

              correctPositionCounter++;
              correctAnswerCheck[i] = "B";
              correctGuessCheck[j] = "B";

            }

            else
            {

              if (correctAnswerCheck[i] == "" && correctGuessCheck[j] == "")
              {
                numberExistsWrongPositionCounter++;
                correctAnswerCheck[i] = "C";
                correctGuessCheck[j] = "C";
              }
            }
          }
        }
      }
      return "BBBB".Substring(0, correctPositionCounter) + "," + "CCCC".Substring(0, numberExistsWrongPositionCounter);
    }

    // public string ReturnOutputAfterGuess()
    // {
    //   int numberExistsWrongPositionCounter = 0;
    //   int correctPositionCounter = 0;
    //   string[] correctAnswerCheck = { "", "", "", "" };
    //   string[] correctGuessCheck = { "", "", "", "" };
    //   for (int i = 0; i < 4; i++)
    //   {
    //     for (int j = 0; j < 4; j++)
    //     {
    //       if (GameAnswer.CorrectAnswer[i] == PlayerGuess.Guess[j] && correctAnswerCheck[i] != "X" && correctGuessCheck[j] != "X")
    //       {
    //         correctAnswerCheck[i] = "X";
    //         correctGuessCheck[j] = "X";

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

    public void CheckIfGameIsOver()
    {
      if (PlayerGuess.OutPutResult == "BBBB,")
      {
        PlayerGuess.PlayerIsGuessing = false;
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
