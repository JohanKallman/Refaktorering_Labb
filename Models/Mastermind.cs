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
            PlayerGuess.NumberOfGuesses = 1;
            GameAnswer.HighestRandomNumber = 7;
            GameAnswer.AmountOfIntegersInAnswer = 4;
            GameAnswer.LowestRandomNumber = 1;
        }

        public override void PrepareRoundResult()
        {
            PlayerGuess.OutPutResult = ReturnOutputAfterGuess();
            PlayerGuess.Guess = FromNumberToColor();
        }

        public string FromNumberToColor()
        {
            var intArray = ConvertStringToIntArray();
            PlayerGuess.Guess = "";
            foreach (var number in intArray)
            {
                PlayerGuess.Guess += (Color)number + ", ";
            }
            return PlayerGuess.Guess;
        }

        public int[] ConvertStringToIntArray()
        {
            //return PlayerGuess.Select(c => c - '0').ToArray();
            return PlayerGuess.Guess.Select(x => int.Parse(x.ToString())).ToArray();
        }
    }
}