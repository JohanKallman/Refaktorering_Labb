using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring_Lab.Interfaces;
using Refactoring_Lab.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring_Lab.Tests
{
    [TestClass]
    public class PlayerGuessTest
    {
        readonly Game game = new Mastermind();
        readonly PlayerGuess playerGuess = new PlayerGuess();
        readonly GameAnswer gameAnswer = new GameAnswer();

        [TestMethod]
        [DataRow("1332", true)]
        [DataRow("133", true)]
        [DataRow("1337777", true)]

        [DataRow("AAAA", false)]
        [DataRow("13BB", false)]
        [DataRow("111guess", false)]
        [DataRow("guess", false)]
        public void CheckIfCorrectCharFormat(string input, bool expected)
        {
            playerGuess.Guess = input;
            bool result = playerGuess.CheckIfCorrectCharFormat();
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        [DataRow("1332", true)]
        [DataRow("13BB", true)]
        [DataRow("AAAA", true)]

        [DataRow("133", false)]
        [DataRow("1337777", false)]
        [DataRow("111guess", false)]
        [DataRow("guess", false)]
        //[DataRow("", false)]
        public void CheckIfCorrectLengthFormat(string input, bool expected)
        {
            gameAnswer.AmountOfIntegersInAnswer = 4;
            playerGuess.Guess = input;
            bool result = playerGuess.CheckIfCorrectLengthFormat(game);
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        [DataRow(5, 0)]
        public void ResetGuessingCounter(int input, int expected)
        {
            playerGuess.NumberOfGuesses = input;
            playerGuess.ResetGuessingCounter();
            int result = playerGuess.NumberOfGuesses;
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        [DataRow(5, 6)]
        public void IncrementGuessingCounterByOne(int input, int expected)
        {
            playerGuess.NumberOfGuesses = input;
            playerGuess.IncrementGuessingCounterByOne();
            int result = playerGuess.NumberOfGuesses;
            Assert.AreEqual(result, expected);
        }


        [TestMethod]
        [DataRow("1111", "1111")]
        [DataRow("1111   ", "1111")]
        [DataRow("  11", "11")]
        public void PlayerGuesses(string input, string expected)
        {
            Console.SetIn(new StringReader(input));
            playerGuess.PlayerGuesses();
            string result = playerGuess.Guess;
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        [DataRow("1111", 4, true)]
        [DataRow("111111", 4, false)]
        [DataRow("f2", 4, false)]
        public void CheckIfAcceptedFormat(string input, int allowedInputLength, bool expected)
        {
            playerGuess.Guess = input;
            gameAnswer.AmountOfIntegersInAnswer = allowedInputLength;
            bool result = playerGuess.CheckIfAcceptedFormat(game);
           
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        [DataRow("1111", 4, true)]
        [DataRow("111111", 4, false)]
        [DataRow("f2", 4, false)]
        public void ValidateInputGuess(string input, int allowedInputLength, bool expected)
        {
            playerGuess.Guess = input;
            gameAnswer.AmountOfIntegersInAnswer = allowedInputLength;
            playerGuess.ValidateInputGuess(game);
            bool result = playerGuess.IsValidGuess;
            Assert.AreEqual(result, expected);

        }
    }
}
