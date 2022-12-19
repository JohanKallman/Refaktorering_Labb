using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring_Lab.Models;

namespace Refactoring_Lab.Tests
{
    [TestClass]
    public class MastermindTest
    {
        readonly Mastermind mastermind = new Mastermind();

        [TestMethod]
        [DataRow("123", 4, "1234")]
        [DataRow("123", 3, "1233")]
        public void FormatAnswerToSpecificGame(string input, int numberToAdd, string expected)
        {
            string result = mastermind.FormatAnswerToSpecificGame(input, numberToAdd);

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        [DataRow("123", "Red, Green, Blue, ")]
        [DataRow("456", "Yellow, Cyan, Magenta, ")]
        public void FromNumberToColor(string input, string expected)
        {
            mastermind.PlayerGuess.Guess = input;

            string result = mastermind.FromNumberToColor();

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        [DataRow("1234", new[] { 1, 2, 3, 4 })]
        public void ConvertStringToIntArray(string input, int[] expected)
        {
            mastermind.PlayerGuess.Guess = input;

            int[] result = mastermind.ConvertStringToIntArray();

            CollectionAssert.AreEqual(result, expected);
        }
    }
}
