using Refactoring_Lab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring_Lab.Interfaces
{
    public interface IPlayerGuess
    {
        string OutPutResult { get; set; }
        bool PlayerIsGuessing { get; set; }
        string Guess { get; set; }
        int NumberOfGuesses { get; set; }
        bool IsValidGuess { get; set; }
        void ResetGuessingCounter();
        void IncrementGuessingCounterByOne();
        void PlayerGuesses();
        bool CheckIfCorrectCharFormat();
        bool CheckIfCorrectLengthFormat(Game game);
        bool CheckIfAcceptedFormat(Game game);
        void ValidateInputGuess(Game game);


    }
}
