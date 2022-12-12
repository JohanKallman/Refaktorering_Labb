using Refactoring_Lab.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using static System.Net.WebRequestMethods;

namespace Refactoring_Lab.Models
{
    public class Statistics : IStatistics
    {
        private List<PlayerData> playerResults = new List<PlayerData>();
        public string TopListData { get; set; }

        public void SaveGameResultToFile(string playerName, int numberOfGuesses, string topListData)
        {
            TopListData = topListData;
            StreamWriter resultOutput = new StreamWriter(TopListData, append: true);
            resultOutput.WriteLine(playerName + "#&#" + numberOfGuesses);
            resultOutput.Close();
        }

        public string CreateSortedTopList()
        {
            CreateDataForTopList();

            playerResults.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
            string topList = "Player   games   average\n";

            foreach (PlayerData player in playerResults)
            {
               topList += string.Format("{0,-9}{1,5:D}{2,9:F2}", player.PlayerName, player.NumberOfGames, player.Average()) +"\n";
            }
            return topList;
        }

        public void CreateDataForTopList()
        {
            StreamReader input = new StreamReader(TopListData);
            string inputLine;

            while ((inputLine = input.ReadLine()) != null)
            {
                PlayerData player = CreatePlayerWithNameAndScore(inputLine);
                int playerIndex = playerResults.IndexOf(player);

                if (CheckIfPlayerExists(playerIndex) == false)
                {
                    playerResults.Add(player);
                }
                else
                {
                    UpdatePlayerData(playerIndex, player);
                }
            }
            input.Close();
        }

        public PlayerData CreatePlayerWithNameAndScore(string inputLine)
        {
            string[] playerNameAndScore = inputLine.Split(new string[] { "#&#" }, StringSplitOptions.None);
            string playerName = playerNameAndScore[0];
            int playerScore = Convert.ToInt32(playerNameAndScore[1]);
            PlayerData player = new PlayerData(playerName, playerScore);
            return player;
        }

        public bool CheckIfPlayerExists(int playerIndex)
        {
            if (playerIndex < 0)
            {
                return false;
            }
            return true;
        }

        public void UpdatePlayerData(int playerIndex, PlayerData player)
        {
            playerResults[playerIndex].UpdateTotalGuesses(player.TotalGuesses);
            playerResults[playerIndex].UpdateNumberOfGames();
        }
    }
}