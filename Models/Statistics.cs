using Refactoring_Lab.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using static System.Net.WebRequestMethods;

namespace Refactoring_Lab.Models
{
    public class Statistics : IStatistics
    {
        public List<PlayerData> playerResults = new List<PlayerData>();

        public void SaveGameResultToFile(string playerName, int numberOfGuesses, string gameName, string fileName)
        {
            StreamWriter resultOutput = new StreamWriter(fileName, append: true);
            resultOutput.WriteLine(playerName + "#&#" + numberOfGuesses + "#&#" + gameName);
            resultOutput.Close();
        }

        public string CreateTopList(string gameName, string fileName)
        {
            CreateDataForTopList(gameName, fileName);
            return SortTopListData();
        }

        public string SortTopListData()
        {
            playerResults.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
            string topList = "Player   games   average\n";

            foreach (PlayerData player in playerResults)
            {
                topList += string.Format("{0,-9}{1,5:D}{2,9:F2}", player.PlayerName, player.NumberOfGames, player.Average()) + "\n";
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
                //TODO: döp om till något med player&game...
                string[] playerNameAndScore = inputLine.Split(new string[] { "#&#" }, StringSplitOptions.None);
                string game = playerNameAndScore[2];

                if (gameName == game)
                {
                    PlayerData player = CreatePlayerWithNameAndScore(playerNameAndScore);
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

        public PlayerData CreatePlayerWithNameAndScore(string[] playerNameAndScore)
        {
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