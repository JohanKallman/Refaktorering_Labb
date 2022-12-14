using Refactoring_Lab.Interfaces;

namespace Refactoring_Lab.Models
{
  public class MooGame : Game
  {
    public MooGame()
    {
      GameName = "Moo Game";
      Rules = "Guess must contain 4 characters between 0-9!";
      PlayerGuess.NumberOfGuesses = 0;
      GameAnswer.HighestRandomNumber = 10;
      GameAnswer.LowestRandomNumber = 0;
      GameAnswer.AmountOfIntegersInAnswer = 4;
    }

    // public override string CheckIfUniqueNumberIsRequired(string correctAnswer, int newNumber)
    // {
    //   if (!correctAnswer.Contains(newNumber.ToString()))
    //   {
    //     correctAnswer += newNumber.ToString();
    //   }

    //   return correctAnswer;
    // }
  }
}
