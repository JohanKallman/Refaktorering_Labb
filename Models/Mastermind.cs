using System.Linq;

namespace Refactoring_Lab.Models
{
    public class Mastermind : Game
    {
        public Mastermind()
        {
            GameName = "Mastermind";
            Rules = "\nGuess must contain 4 different colors. \nChoose between (1)Red, (2)Green, (3)Blue, (4)Yellow, (5)Cyan or (6)Magenta.";
            PlayerGuess.NumberOfGuesses = 1;
            GameAnswer.HighestRandomNumber = 7;
            GameAnswer.AmountOfIntegersInAnswer = 4;
            GameAnswer.LowestRandomNumber = 1;
            GameWinningCondition = "BBBB,";
        }

        public override void PrepareRoundResult(Game game)
        {
            PlayerGuess.OutputResult = OutputResult.ReturnOutputAfterGuess(game);
            PlayerGuess.Guess = FromNumberToColor();
        }

        public override string FormatAnswerToSpecificGame(string correctAnswer, int newNumber)
        {
            return correctAnswer += newNumber.ToString();
        }

        public string FromNumberToColor()
        {
            int[] guessArray = ConvertStringToIntArray();
            PlayerGuess.Guess = "";
            foreach (int number in guessArray)
            {
                PlayerGuess.Guess += (Color)number + ", ";
            }
            return PlayerGuess.Guess;
        }

        public int[] ConvertStringToIntArray()
        {
            return PlayerGuess.Guess.Select(x => int.Parse(x.ToString())).ToArray();
        }


    }
}