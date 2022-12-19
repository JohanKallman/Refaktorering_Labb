using System;

namespace Refactoring_Lab.Models
{
    public class OutputResultService
    {
        string _correctAnswer = "";
        string _guess = "";
        int _correctPositionCounter = 0;
        int _numberExistsWrongPositionCounter = 0;
        string[] _correctAnswerCheck = { "", "", "", "" };
        string[] _correctGuessCheck = { "", "", "", "" };
        string _rightPosition;
        string _wrongPosition;
        int i;
        int j;

        public string ReturnOutputAfterGuess(Game game)
        {
            SetFields(game);
            ResetResultOutputCheckers();
            CheckCorrectAnswer();
            return _rightPosition.Substring(0, _correctPositionCounter) + "," + _wrongPosition.Substring(0, _numberExistsWrongPositionCounter);
        }

        public void SetFields(Game game)
        {
            _correctAnswer = game.GameAnswer.CorrectAnswer;
            _guess = game.PlayerGuess.Guess;
            _rightPosition = game.GameWinningCondition;
            _wrongPosition = new string('C', _rightPosition.Length);
        }

        public void ResetResultOutputCheckers()
        {
            Array.Clear(_correctAnswerCheck, 0, _correctAnswerCheck.Length);
            Array.Clear(_correctGuessCheck, 0, _correctGuessCheck.Length);
            _correctPositionCounter = 0;
            _numberExistsWrongPositionCounter = 0;
        }

        public void CheckCorrectAnswer()
        {
            for (i = 0; i < _correctAnswer.Length; i++)
            {
                CheckPlayerGuess();
            }
            i = 0;
        }

        public void CheckPlayerGuess()
        {
            for (j = 0; j < _guess.Length; j++)
            {
                CheckIfCorrectAnswerContainsGuess();
            }
            j = 0;
        }

        public void CheckIfCorrectAnswerContainsGuess()
        {
            if (_correctAnswer[i] == _guess[j])
            {
                CheckIfGuessIsInRightOrWrongPosition();
            }
        }

        public void CheckIfGuessIsInRightOrWrongPosition()
        {
            if (i == j)
            {
                AddRightPositionToResult();
            }
            else
            {
                AddWrongPositionToResult();
            }
        }
        public void AddRightPositionToResult()
        {
            CheckAndAdjustWrongPositionCounter();
            _correctPositionCounter++;
            _correctAnswerCheck[i] = "B";
            _correctGuessCheck[j] = "B";
        }

        public void AddWrongPositionToResult()
        {
            if (_correctAnswerCheck[i] == null && _correctGuessCheck[j] == null)
            {
                _numberExistsWrongPositionCounter++;
                _correctAnswerCheck[i] = "C";
                _correctGuessCheck[j] = "C";
            }
        }
        public void CheckAndAdjustWrongPositionCounter()
        {
            if (_correctAnswerCheck[i] == "C" || _correctGuessCheck[i] == "C")
            {
                _numberExistsWrongPositionCounter--;
            }
        }
    }
}
    

