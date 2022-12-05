using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using refaktorering_labb.Interfaces;
using Refaktorering_Labb.Models;

namespace refaktorering_labb.Models
{
    public class Mastermind : IGame
    {
        public string GameName { get; set; } = "Mastermind";
        public string Rules { get; set; } = "Guess must contain 4 different colors. Choose between (1)Red, (2)Green, (3)Blue, (4)Yellow, (5)Cyan or (6)Magenta.";
        public bool PlayerIsGuessing { get; set; }
        public string CorrectAnswer { get; set; }
        public int NumberOfGuesses { get; set; }
        public string PlayerGuess { get; set; }
        public string CorrectAnswerInColor { get; set; }
        public string PlayerName { get; set; }
        public int HighestRandomNumber { get; set; } = 6;
        public int AmountOfIntegersInAnswer { get; set; } = 4;

        public Mastermind()
        {
        }

        public string GenerateCorrectAnswer()
        {
            Random numberGenerator = new Random();
            string uniqueNumberToReturn = "";
            while (uniqueNumberToReturn.Length < AmountOfIntegersInAnswer)
            {
                int newNumber = numberGenerator.Next(HighestRandomNumber);
                if (!uniqueNumberToReturn.Contains(newNumber.ToString()))
                {
                    uniqueNumberToReturn += newNumber.ToString();
                }
            }
            return uniqueNumberToReturn;
        }

        //public static string GenerateCorrectAnswer(int topOfGuessingNumberSpan)
        //{
        //    // DO BETTER
        //    Random randomGenerator = new Random();
        //    string correctAnswer = "";
        //    for (int i = 0; i < 4; i++)
        //    {
        //        int random = randomGenerator.Next(topOfGuessingNumberSpan);
        //        string randomDigit = random.ToString();
        //        while (correctAnswer.Contains(randomDigit))
        //        {
        //            random = randomGenerator.Next(topOfGuessingNumberSpan);
        //            randomDigit = random.ToString();
        //        }
        //        correctAnswer = correctAnswer + randomDigit;
        //    }

        //    return correctAnswer;
        //}

        public void StartNewInstanceOfGame()
        {
            CorrectAnswer = GenerateCorrectAnswer();
            CorrectAnswerInColor = FromNumberToColor(CorrectAnswer);
            Console.WriteLine("For practice, number is: " + CorrectAnswer + "\n"); // Till UI
        }



        public bool CheckIfCorrectLength(string guess)
        {
            int numberOfAllowedCharachters = 4;
            if (guess.Length == numberOfAllowedCharachters)
            {
                return true;
            }
            return false;
        }

        public string PrepareRoundResult(string guess)
        {
            PlayerGuess = FromNumberToColor(guess);
            return ReturnOutputAfterGuess(guess);
        }
        public string ReturnOutputAfterGuess(string guess)
        {

            int numberExistsWrongPositionCounter = 0;
            int correctPositionCounter = 0;
            guess += "    ";     // if player entered less than 4 chars
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (CorrectAnswer[i] == guess[j])
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

        public bool CheckGameWinningCondition(string resultAfterGuess)
        {
            if (resultAfterGuess == "BBBB,")
            {
                return false;
            }
            return true;
        }

        public bool CheckIfPlayAgain(string answer)
        {
            if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
            {
                return false;
            }

            return true;
        }


        public bool CheckIfCorrectLengthFormat(string guess)
        {
            int numberOfAllowedCharachters = 4;
            if (guess.Length == numberOfAllowedCharachters)
            {
                return true;
            }

            return false;
        }

        public bool CheckIfCorrectCharFormat(string guess)
        {
            if (guess.All(char.IsDigit))
            {
                return true;
            }

            return false;
        }

        public string PlayerGuesses()
        {

            NumberOfGuesses++;

            return Console.ReadLine().Trim();

            //return FromNumberToColor(guess);

        }

        private string FromNumberToColor(string guess)
        {
            var correctAnswerInColor = "";
            foreach (var number in guess)
            {
                PlayerGuess += (Color)number + ",";
            }

            return correctAnswerInColor;
        }




    }
}