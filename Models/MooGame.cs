namespace Refactoring_Lab.Models
{
  public class MooGame : Game
  {

    public MooGame()
    {
      GameName = "Moo Game";
      Rules = "Guess must contain 4 characters between 0-9!";
      GameIsRunning = false;
      CorrectAnswer = "";
      NumberOfGuesses = 0;
      HighestRandomNumber = 10;
      LowestRandomNumber = 0;
      AmountOfIntegersInAnswer = 4;

    }


    //public override void PrepareRoundResult()
    //{

    //    OutPutResult = ReturnOutputAfterGuess();

    //}

  }
}