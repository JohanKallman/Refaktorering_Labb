using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring_Lab.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public void CheckIfPlayerExists(int playerIndex)
        {

        }
        //public bool CheckIfPlayerExists(int playerIndex)
        //{
        //    if (playerIndex < 0)
        //    {
        //        return false;
        //    }
        //    return true;
        //}




    }
}
