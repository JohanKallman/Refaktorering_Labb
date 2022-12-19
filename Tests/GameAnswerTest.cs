using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring_Lab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring_Lab.Tests
{
    [TestClass]
    public class GameAnswerTest
    {
        readonly GameAnswer gameAnswer = new GameAnswer();
        readonly Game mastermind = new Mastermind();
        readonly Game mooGame = new Mastermind();

        [TestMethod]
        [DataRow(1, 7)]
        public void GenerateCorrectAnswerMastermind(int lowest, int highest)
        {
            gameAnswer.AmountOfIntegersInAnswer = 4;
            gameAnswer.LowestRandomNumber = lowest;
            gameAnswer.HighestRandomNumber = highest;

            string result = gameAnswer.GenerateCorrectAnswer(mastermind);
            bool isDigit = Int32.TryParse(result, out int resultInt);

            Assert.AreEqual(result.Length, gameAnswer.AmountOfIntegersInAnswer);
            Assert.AreEqual(resultInt.GetType(), 1.GetType());
            Assert.AreEqual(isDigit, true);
        }

        [TestMethod]
        [DataRow(0, 10)]
        public void GenerateCorrectAnswerMooGame(int lowest, int highest)
        {
            gameAnswer.AmountOfIntegersInAnswer = 4;
            gameAnswer.LowestRandomNumber = lowest;
            gameAnswer.HighestRandomNumber = highest;

            string result = gameAnswer.GenerateCorrectAnswer(mooGame);
            bool isDigit = Int32.TryParse(result, out int resultInt);

            Assert.AreEqual(result.Length, gameAnswer.AmountOfIntegersInAnswer);
            Assert.AreEqual(resultInt.GetType(), 1.GetType());
            Assert.AreEqual(isDigit, true);
        }
    }
}
