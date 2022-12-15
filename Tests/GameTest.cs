using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring_Lab.Models;
using System;
using System.Collections.Generic;
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
    }
}
