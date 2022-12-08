// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using Refactoring_Lab.Models;

// namespace Refactoring_Lab.Tests
// {
//     [TestClass]
//     public class MasterMindTest
//     {
//         readonly Mastermind mastermind = new Mastermind();

//         //[TestMethod]
//         //[DataRow(new[] {1, 2, 3,}, "Red, Green, Blue,")]
//         //[DataRow(new[] {4, 5, 6,}, "Yellow, Cyan, Magenta,")]
//         //public void FromNumberToColor(int[] input, string expected)
//         //{

//         //    //expected = mastermind.PlayerGuess;
//         //    mastermind.PlayerGuess = expected;
//         //    string result = mastermind.FromNumberToColor();
//         //    Assert.AreEqual(result, expected);

//         //    //mastermind.PlayerGuess = expected;
//         //    //string result = mastermind.FromNumberToColor();
//         //    //Assert.AreEqual(result, mastermind.PlayerGuess);
//         //}

//         [TestMethod]
//         [DataRow("123", "Red, Green, Blue, ")]
//         [DataRow("456", "Yellow, Cyan, Magenta, ")]
//         public void FromNumberToColor(string input, string expected)
//         {
//             mastermind.PlayerGuess = input;
//             string result = mastermind.FromNumberToColor();
//             Assert.AreEqual(result, expected);

//         }

//         [TestMethod]
//         [DataRow("1234", new[] { 1, 2, 3, 4 })]
//         public void ConvertStringToIntArray(string input, int[] expected)
//         {
//             mastermind.PlayerGuess = input;
//             int[] result = mastermind.ConvertStringToIntArray();
//             CollectionAssert.AreEqual(result, expected);
//         }




//     }
// }
