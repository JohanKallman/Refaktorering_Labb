using System.Linq;

namespace Refactoring_Lab.Models
{
    public class Mastermind : Game
  {


    public Mastermind()
    {
      GameName = "Mastermind";
      Rules = "Guess must contain 4 different colors. Choose between (1)Red, (2)Green, (3)Blue, (4)Yellow, (5)Cyan or (6)Magenta.";

      GameIsRunning = false;
      PlayerGuessing = true;
      CorrectAnswer = "";
      NumberOfGuesses = 1;
      HighestRandomNumber = 7;
      AmountOfIntegersInAnswer = 4;

    }


    public override void PrepareRoundResult()
    {

      OutPutResult = ReturnOutputAfterGuess();
      FromNumberToColor();

    }
    public void FromNumberToColor()
    {

      //Skapa test och metod och bryt ut konverteringen
      var intArray = PlayerGuess.Select(c => c - '0').ToArray();
      PlayerGuess = "";
      foreach (var number in intArray)
      {

        PlayerGuess += (Color)number + ",";
      }



    }



  }
}