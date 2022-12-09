namespace Refactoring_Lab.Models
{
    public class MooGame : Game
    {

        public MooGame()
        {
            GameName = "Moo Game";
            Rules = "Guess must contain 4 characters between 0-9!";
            TopOfGuessingNumberSpan = 10;
            GameIsRunning = false;
            PlayerGuessing = true;
            CorrectAnswer = "";
            NumberOfGuesses = 0;
            HighestRandomNumber = 10;
            AmountOfIntegersInAnswer = 4;
            LowestRandomNumber = 0;

        }


        //public override void PrepareRoundResult()
        //{

        //    OutPutResult = ReturnOutputAfterGuess();

        //}

    }
}