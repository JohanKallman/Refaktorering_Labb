﻿using Refactoring_Lab.Interfaces;
using System;

namespace Refactoring_Lab.Models
{
    public abstract class Game
    {
        public string GameName { get; set; }
        public string Rules { get; set; }
        public bool GameIsRunning { get; set; } = false;
        public IAnswerService GameAnswer { get; set; } = new GameAnswer();
        public IPlayerGuess PlayerGuess { get; set; } = new PlayerGuess();

        public void StartNewInstanceOfGame(Game game)
        {
            PlayerGuess.ResetGuessingCounter();
            GameAnswer.CorrectAnswer = GameAnswer.GenerateCorrectAnswer(game);
            Console.WriteLine("For practice, number is: " + GameAnswer.CorrectAnswer + "\n");
        }

        public virtual void PrepareRoundResult()
        {
            PlayerGuess.OutPutResult = ReturnOutputAfterGuess();
        }

        public virtual string FormatAnswerToSpecificGame(string correctAnswer, int newNumber)
        {
            if (!correctAnswer.Contains(newNumber.ToString()))
            {
                correctAnswer += newNumber.ToString();
            }
            return correctAnswer;
        }

        public string ReturnOutputAfterGuess()
        {
            int numberExistsWrongPositionCounter = 0;
            int correctPositionCounter = 0;
            string[] correctAnswerCheck = { "", "", "", "" };
            string[] correctGuessCheck = { "", "", "", "" };
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (GameAnswer.CorrectAnswer[i] == PlayerGuess.Guess[j])
                    {
                        if (i == j)
                        {
                            if (correctAnswerCheck[i] == "C" || correctGuessCheck[i] == "C")
                            {
                                numberExistsWrongPositionCounter--;
                            }
                            correctPositionCounter++;
                            correctAnswerCheck[i] = "B";
                            correctGuessCheck[j] = "B";
                        }
                        else
                        {
                            if (correctAnswerCheck[i] == "" && correctGuessCheck[j] == "")
                            {
                                numberExistsWrongPositionCounter++;
                                correctAnswerCheck[i] = "C";
                                correctGuessCheck[j] = "C";
                            }
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
            if (Console.ReadLine().Trim().ToUpper() == "Q")
            {
                return false;
            }
            return true;
        }
    }
}
