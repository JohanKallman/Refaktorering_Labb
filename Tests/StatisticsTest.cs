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

        //public string SortTopListData()
        //{
        //    playerResults.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
        //    string topList = "Player   games   average\n";

        //    foreach (PlayerData player in playerResults)
        //    {
        //        topList += string.Format("{0,-9}{1,5:D}{2,9:F2}", player.PlayerName, player.NumberOfGames, player.Average()) + "\n";
        //    }
        //    playerResults.Clear();
        //    return topList;
        //}

        public void SortTopListData()
        {

        }
    }
}
