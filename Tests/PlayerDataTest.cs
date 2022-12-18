using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class PlayerDataTest
    {
        readonly PlayerData playerData = new PlayerData();

        [TestMethod]
        [DataRow(10, 2, 5)]
        [DataRow(7, 4, 1.75)]
        public void CalculateAverage(int totalGuesses, int numberOfGames, double expected)
        {
            playerData.TotalGuesses = totalGuesses;
            playerData.NumberOfGames = numberOfGames;

            double result = playerData.CalculateAverageScore();
            Assert.AreEqual(result, expected);     
        }

        [TestMethod]
        [DataRow("Name", "Name")]
        [DataRow("", "No Name")]
        [DataRow("   ", "No Name")]
        //[DataRow(null, "No Name")]
        public void SetPlayerName(string inputName, string expected)
        {
            Console.SetIn(new StringReader(inputName));
            playerData.SetPlayerName();
            var result = playerData.PlayerName;
            StringAssert.Equals(result, expected);
        }

        [TestMethod]
        [DataRow(5, 6)]
        [DataRow(100, 101)]
        public void UpdateNumberOfGames(int input, int expected)
        {
            playerData.NumberOfGames = input;
            playerData.UpdateNumberOfGames();
            int result = playerData.NumberOfGames;
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        [DataRow(5, 3, 8)]
        [DataRow(24, 10, 34)]
        public void UpdateTotalGuesses(int input, int numberToAdd, int expected)
        {
            playerData.TotalGuesses = input;
            playerData.UpdateTotalGuesses(numberToAdd);
            int result = playerData.TotalGuesses;

            Assert.AreEqual(result, expected);
        }


    }
}
