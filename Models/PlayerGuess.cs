using Refactoring_Lab.Interfaces;
using System;
using System.Linq;

namespace Refactoring_Lab.Models
{
    public class PlayerGuess : IPlayerGuess
    {
        public string OutPutResult { get; set; }
        public bool PlayerIsGuessing { get; set; }
        public string Guess { get; set; }
        public int NumberOfGuesses { get; set; }
        public bool IsValidGuess { get; set; }

        public void ResetGuessingCounter()
        {
            NumberOfGuesses = 0;
        }

        public void IncrementGuessingCounterByOne()
        {
            NumberOfGuesses++;
        }

        public void PlayerGuesses()
        {
            Guess = Console.ReadLine().Trim();
            IncrementGuessingCounterByOne();
        }

        public bool CheckIfCorrectCharFormat()
        {
            if (Guess.All(char.IsDigit))
            {
                return true;
            }
            return false;
        }

        public bool CheckIfCorrectLengthFormat(Game game)
        {
            if (Guess.Length == game.GameAnswer.AmountOfIntegersInAnswer)
            {
                return true;
            }
            return false;
        }

        public void ValidateInputGuess(Game game)
        {
            IsValidGuess = CheckIfAcceptedFormat(game);
        }

        public bool CheckIfAcceptedFormat(Game game)
        {
            bool guessHasCorrectFormat = CheckIfCorrectLengthFormat(game);
            if (guessHasCorrectFormat == false)
            {
                return false;
            }
            return CheckIfCorrectCharFormat();
        }
    }
}
