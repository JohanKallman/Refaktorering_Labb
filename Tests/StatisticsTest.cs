using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring_Lab.Interfaces;
using Refactoring_Lab.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring_Lab.Tests
{
    [TestClass]
    public class StatisticsTest
    {
        readonly Statistics statistics = new Statistics();

        [TestMethod]
        [DataRow("PlayerName", 3, "GameName", "PlayerName#&#3#&#GameName")]
        public void SaveGameResultToFile(string inputName, int inputGuesses, string gameName, string expected)
        {
            statistics.SaveGameResultToFile(inputName, inputGuesses, gameName, "testresult.txt");

            StreamReader input = new StreamReader("testresult.txt");

            string inputLine;
            inputLine = input.ReadLine();
            input.Close();

            Assert.AreEqual(inputLine, expected);
        }

        [TestMethod]
        [DataRow(4, 10, 5, 13)]
        public void UpdatePlayerData(int numberOfGames, int totalGuesses, int expectedNumberOfGames, int expectedtotalGuesses)
        {
            PlayerData playerData = new PlayerData();
            playerData.TotalGuesses = totalGuesses;
            playerData.NumberOfGames = numberOfGames;
            statistics.playerResults.Add(playerData);

            PlayerData playerData2 = new PlayerData();
            playerData2.TotalGuesses = 3;
            statistics.UpdatePlayerData(0, playerData2);

            int resultTotalGuesses = statistics.playerResults[0].TotalGuesses;
            int resultNumberOfGames = statistics.playerResults[0].NumberOfGames;

            Assert.AreEqual(resultTotalGuesses, expectedtotalGuesses);
            Assert.AreEqual(resultNumberOfGames, expectedNumberOfGames);

            statistics.playerResults.Clear();
        }

        [TestMethod]
        [DataRow(-1, false)]
        [DataRow(0, true)]
        [DataRow(1, true)]
        public void CheckIfPlayerExists(int playerIndex, bool expected)
        {
            bool result = statistics.CheckIfPlayerExists(playerIndex);
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        [DataRow(new string[] { "name", "10" }, 10, "name")]
        public void CreatePlayerWithNameAndScore(string[] input, int expectedScore, string expectedName)
        {
            PlayerData playerResult = statistics.CreatePlayerWithNameAndScore(input);

            string playerName = playerResult.PlayerName;
            int playerScore = playerResult.TotalGuesses;

            Assert.AreEqual(playerName, expectedName);
            Assert.AreEqual(playerScore, expectedScore);
        }

        [TestMethod]
        public void SortTopListData()
        {
            PlayerData player1 = new PlayerData();
            player1.PlayerName = "Player1";
            player1.TotalGuesses = 10;
            player1.NumberOfGames = 2;

            PlayerData player2 = new PlayerData();
            player1.PlayerName = "Player2";
            player2.TotalGuesses = 20;
            player2.NumberOfGames = 2;

            statistics.playerResults.Add(player1);
            statistics.playerResults.Add(player2);

            string result = statistics.SortTopListData();

            string expected = "Player   games   average\n";
            expected += string.Format("{0,-9}{1,5:D}{2,9:F2}", player1.PlayerName, player1.NumberOfGames, player1.CalculateAverageScore()) + "\n";
            expected += string.Format("{0,-9}{1,5:D}{2,9:F2}", player2.PlayerName, player2.NumberOfGames, player2.CalculateAverageScore()) + "\n";

            Assert.AreEqual(result, expected);

            string expectedFail = "Player   games   average\n";
            expectedFail += string.Format("{0,-9}{1,5:D}{2,9:F2}", player2.PlayerName, player2.NumberOfGames, player2.CalculateAverageScore()) + "\n";
            expectedFail += string.Format("{0,-9}{1,5:D}{2,9:F2}", player1.PlayerName, player1.NumberOfGames, player1.CalculateAverageScore()) + "\n";

            Assert.AreNotEqual(result, expectedFail);
        }
    }
}
