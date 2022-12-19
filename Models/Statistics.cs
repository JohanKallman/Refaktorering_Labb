using Refactoring_Lab.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace Refactoring_Lab.Models
{
    public class Statistics : IStatistics
    {
        public List<PlayerData> playerResults = new List<PlayerData>();
        private readonly string _separator = "#&#";
        private readonly string _topListHeader = "Player   games   average\n";

        public void SaveGameResultToFile(string playerName, int numberOfGuesses, string gameName, string fileName)
        {
            StreamWriter resultOutput = new StreamWriter(fileName, append: true);
            resultOutput.WriteLine(playerName + _separator + numberOfGuesses + _separator + gameName);
            resultOutput.Close();
        }

        public string CreateTopList(string gameName, string fileName)
        {
            CreateDataForTopList(gameName, fileName);
            return SortTopListData();
        }

        public string SortTopListData()
        {
            playerResults.Sort((p1, p2) => p1.CalculateAverageScore().CompareTo(p2.CalculateAverageScore()));
   
            string topList = _topListHeader;

            foreach (PlayerData player in playerResults)
            {
                topList += string.Format("{0,-9}{1,5:D}{2,9:F2}", player.PlayerName, player.NumberOfGames, player.CalculateAverageScore()) + "\n";
            }
            playerResults.Clear();
            return topList;
        }

        public void CreateDataForTopList(string gameName, string fileName)
        {
            StreamReader input = new StreamReader(fileName);
            string inputLine;

            while ((inputLine = input.ReadLine()) != null)
            {
                string[] playerData = inputLine.Split(new string[] { _separator }, StringSplitOptions.None);
                string game = playerData[2];

                if (gameName == game)
                {
                    PlayerData player = CreatePlayerWithNameAndScore(playerData);
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
            }
            input.Close();
        }

        public PlayerData CreatePlayerWithNameAndScore(string[] playerData)
        {
            string playerName = playerData[0];
            int playerScore = Convert.ToInt32(playerData[1]);
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