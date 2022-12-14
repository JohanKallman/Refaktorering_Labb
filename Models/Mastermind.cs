using System;
using System.Linq;

namespace Refactoring_Lab.Models
{
  public class Mastermind : Game
  {


    public Mastermind()
    {
      GameName = "Mastermind";
      Rules = "\nGuess must contain 4 different colors. \nChoose between (1)Red, (2)Green, (3)Blue, (4)Yellow, (5)Cyan or (6)Magenta.";

      GameIsRunning = false;
      CorrectAnswer = "";
      NumberOfGuesses = 1;
      HighestRandomNumber = 7;
      AmountOfIntegersInAnswer = 4;
      LowestRandomNumber = 1;
    }

    public override void PrepareRoundResult()
    {
      OutPutResult = ReturnOutputAfterGuess();

      PlayerGuess = FromNumberToColor();
    }

    public override string CheckIfUniqueNumberIsRequired(string correctAnswer, int newNumber)
    {
      return correctAnswer += newNumber.ToString();
    }

    //public void FromNumberToColor()
    //{
    //    int[] intArray = ConvertStringToIntArray();
    //    PlayerGuess = "";
    //    foreach (var number in intArray)
    //    {
    //        PlayerGuess += (Color)number + ",";
    //    }
    //}

    public string FromNumberToColor()
    {
      var intArray = ConvertStringToIntArray();
      PlayerGuess = "";
      foreach (var number in intArray)
      {
        PlayerGuess += (Color)number + ", ";
      }

      return PlayerGuess;

    }


    public int[] ConvertStringToIntArray()
    {
      //return PlayerGuess.Select(c => c - '0').ToArray();
      return PlayerGuess.Select(x => int.Parse(x.ToString())).ToArray();
    }
  }
}