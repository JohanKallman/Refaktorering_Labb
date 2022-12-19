using Refactoring_Lab.Interfaces;
using System;

namespace Refactoring_Lab.Models
{
    public abstract class Game
    {
        public string GameName { get; set; }
        public string Rules { get; set; }
        public bool GameIsRunning { get; set; }
        public IAnswerService GameAnswer { get; set; } = new GameAnswer();
        public IPlayerGuess PlayerGuess { get; set; } = new PlayerGuess();
        public OutputResultService OutputResultService { get; set; } = new OutputResultService();
        public string GameWinningCondition { get; set; }

        public void StartNewInstanceOfGame(Game game)
        {
            PlayerGuess.ResetGuessingCounter();
            GameAnswer.CorrectAnswer = GameAnswer.GenerateCorrectAnswer(game);
        }

        public virtual void PrepareRoundResult(Game game)
        {
            PlayerGuess.OutputResult = OutputResultService.ReturnOutputAfterGuess(game);
        }

        public virtual string FormatAnswerToSpecificGame(string correctAnswer, int newNumber)
        {
            if (!correctAnswer.Contains(newNumber.ToString()))
            {
                correctAnswer += newNumber.ToString();
            }
            return correctAnswer;
        }

        public void CheckIfGameIsOver()
        {
            if (PlayerGuess.OutputResult == GameWinningCondition)
            {
                PlayerGuess.PlayerIsGuessing = false;
            }
        }
        public bool CheckIfPlayAgain()
        {
            if (Console.ReadLine().Trim().ToUpper() == "Q")
            {
                return false;
            }
            return true;
        }
    }
}
