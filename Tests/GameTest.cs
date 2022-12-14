using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring_Lab.Models;
using System;
using System.IO;

namespace Refactoring_Lab.Tests
{
    [TestClass]
    public class GameTest
    {
        private readonly Game game = new Mastermind();

        [TestMethod]
        [DataRow("1233", "1233", "BBBB,")]
        [DataRow("1234", "1233", "BBB,")]
        [DataRow("3213", "1233", "BB,CC")]
        public void ReturnOutputAfterGuess(string input, string correctAnswer, string expected)
        {
            game.PlayerGuess.Guess = input;
            game.GameAnswer.CorrectAnswer = correctAnswer;

            string result = game.OutputResultService.ReturnOutputAfterGuess(game);

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        [DataRow("BBBB,", false)]
        [DataRow("BB,CC", true)]
        [DataRow("", true)]
        public void CheckIfGameIsOver(string input, bool expected)
        {
            game.PlayerGuess.PlayerIsGuessing = true;
            game.PlayerGuess.OutputResult = input;
            game.CheckIfGameIsOver();

            bool result = game.PlayerGuess.PlayerIsGuessing;

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        [DataRow("Q", false)]
        [DataRow("q", false)]
        [DataRow("   Q", false)]
        [DataRow("YES", true)]
        public void CheckIfPlayAgain(string input, bool expected)
        {
            Console.SetIn(new StringReader(input));

            bool result = game.CheckIfPlayAgain();

            StringAssert.Equals(result, expected);
        }
    }
}
