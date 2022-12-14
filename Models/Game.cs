using System;
using System.Linq;

namespace Refactoring_Lab.Models
{
    public abstract class Game
    {
        public string GameName { get; set; }
        public string Rules { get; set; }
        public bool GameIsRunning { get; set; } = false;
        public GameAnswer GameAnswer { get; set; } = new GameAnswer();

        public PlayerGuess PlayerGuess { get; set; } = new PlayerGuess();

        public void StartNewInstanceOfGame()
        {
            ResetGuessingCounter();
            GameAnswer.CorrectAnswer = GenerateCorrectAnswer();
            Console.WriteLine("For practice, number is: " + GameAnswer.CorrectAnswer + "\n");
        }

        public virtual void PrepareRoundResult()
        {
            PlayerGuess.OutPutResult = ReturnOutputAfterGuess();
        }

        public string GenerateCorrectAnswer()
        {
            Random numberGenerator = new Random();
            string uniqueNumberToReturn = "";
            while (uniqueNumberToReturn.Length < GameAnswer.AmountOfIntegersInAnswer)
            {
                int newNumber = numberGenerator.Next(GameAnswer.LowestRandomNumber, GameAnswer.HighestRandomNumber);
                if (!uniqueNumberToReturn.Contains(newNumber.ToString()))
                {
                    uniqueNumberToReturn += newNumber.ToString();
                }
            }
            return uniqueNumberToReturn;
        }

        public void ResetGuessingCounter()
        {
            PlayerGuess.NumberOfGuesses = 0;
        }

        public void PlayerGuesses()
        {
            PlayerGuess.Guess = Console.ReadLine().Trim();
            IncrementGuessingCounterByOne();
        }

        public void IncrementGuessingCounterByOne()
        {
            PlayerGuess.NumberOfGuesses++;
        }

        public void ValidateInputGuess()
        {
            PlayerGuess.IsValidGuess = CheckIfAcceptedFormat();
        }

        public bool CheckIfAcceptedFormat()
        {
            bool guessHasCorrectFormat = CheckIfCorrectLengthFormat();
            if (guessHasCorrectFormat == false)
            {
                return false;
            }
            return guessHasCorrectFormat = CheckIfCorrectCharFormat();
        }

        public bool CheckIfCorrectLengthFormat()
        {
            if (PlayerGuess.Guess.Length == GameAnswer.AmountOfIntegersInAnswer)
            {
                return true;
            }
            return false;
        }

        public bool CheckIfCorrectCharFormat()
        {
            if (PlayerGuess.Guess.All(char.IsDigit))
            {
                return true;
            }

            return false;
        }

        public string ReturnOutputAfterGuess()
        {
            int numberExistsWrongPositionCounter = 0;
            int correctPositionCounter = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (GameAnswer.CorrectAnswer[i] == PlayerGuess.Guess[j])
                    {
                        if (i == j)
                        {
                            correctPositionCounter++;
                        }
                        else
                        {
                            numberExistsWrongPositionCounter++;
                        }
                    }
                }
            }
            return "BBBB".Substring(0, correctPositionCounter) + "," + "CCCC".Substring(0, numberExistsWrongPositionCounter);
        }

        public void CheckIfGameIsOver()
        {
            if (PlayerGuess.OutPutResult == "BBBB,")
            {
                PlayerGuess.PlayerIsGuessing = false;
            }
        }
        public bool CheckIfPlayAgain()
        {
            if (Console.ReadLine().ToUpper() == "Q")
            {
                return false;
            }
            return true;
        }
    }


}
