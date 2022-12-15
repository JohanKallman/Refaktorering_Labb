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
{   [TestClass]
    public class GameTest
    {
       private readonly Game game = new Mastermind();

        [TestMethod]
        [DataRow("1233", "1233", "BBBB," )]
        [DataRow("1234", "1233", "BBB," )]
        [DataRow("3213", "1233", "BB,CC" )]
        public void ReturnOutputAfterGuess(string input, string correctAnswer, string expected) 
        {
            game.PlayerGuess.Guess = input;
            game.GameAnswer.CorrectAnswer = correctAnswer;
            string result = game.ReturnOutputAfterGuess();
            Assert.AreEqual(result, expected);         
        }

        [TestMethod]
        [DataRow("BBBB,", false)]
        [DataRow("BB,CC", true)]
        [DataRow("", true)]
        public void CheckIfGameIsOver(string input, bool expected)
        {
            game.PlayerGuess.PlayerIsGuessing = true;
            game.PlayerGuess.OutPutResult = input;
            game.CheckIfGameIsOver();  
            bool result = game.PlayerGuess.PlayerIsGuessing;

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        [DataRow("Q", false)]
        [DataRow("q", false)]
        [DataRow("   Q", false)]

        [DataRow("YES", true)]
        //[DataRow("", true)]
        public void CheckIfPlayAgain(string input, bool expected)
        {       
            Console.SetIn(new StringReader(input));
            bool result = game.CheckIfPlayAgain();
            StringAssert.Equals(result, expected);
        }

        [TestMethod]
        [DataRow("1332", true)]
        [DataRow("133", true)]
        [DataRow("1337777", true)]

        [DataRow("AAAA", false)]
        [DataRow("13BB", false)]
        [DataRow("111guess", false)]
        [DataRow("guess", false)]
        //[DataRow("", false)]
        public void CheckIfCorrectCharFormat(string input, bool expected)
        {
           game.PlayerGuess.Guess = input;
           bool result = game.CheckIfCorrectCharFormat();
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
            game.GameAnswer.AmountOfIntegersInAnswer = 4;
            game.PlayerGuess.Guess = input;
            bool result = game.CheckIfCorrectLengthFormat();
            Assert.AreEqual(result, expected);
        }

    }
}
