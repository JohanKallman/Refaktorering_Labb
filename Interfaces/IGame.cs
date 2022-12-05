using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using refaktorering_labb.Models;

namespace refaktorering_labb.Interfaces
{
  public interface IGame
  {

    public string GameName { get; set; }
    public string Rules { get; set; }
    public int TopOfGuessingNumberSpan { get; set; }
    public bool PlayerIsGuessing { get; set; }
    public string CorrectAnswer { get; set; }
    public int NumberOfGuesses { get; set; }
    public string PlayerGuess { get; set; }
    public string PlayerName { get; set; }


    void StartNewInstanceOfGame();
    string ReturnOutputAfterGuess(string inputGuess);
    bool CheckGameWinningCondition(string outputResult);
    bool CheckIfPlayAgain(string answer);
    bool CheckIfCorrectLengthFormat(string guess);
    bool CheckIfCorrectCharFormat(string guess);
    string PlayerGuesses();
    string PrepareRoundResult(string inputGuess);
  }
}