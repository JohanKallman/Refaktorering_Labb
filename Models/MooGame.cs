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
    }
}
